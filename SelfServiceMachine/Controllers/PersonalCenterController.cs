using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Models.Response;
using SelfServiceMachine.Service.Service;

namespace SelfServiceMachine.Controllers
{
    /// <summary>
    /// 个人中心
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalCenterController : ControllerBase
    {
        private PtInfoBLL ptInfoBLL;
        private CardInfoBLL cardInfoBLL;
        private FeeinfoBLL feeinfoBLL;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PersonalCenterController()
        {
            ptInfoBLL = new PtInfoBLL();
            cardInfoBLL = new CardInfoBLL();
            feeinfoBLL = new FeeinfoBLL();
        }

        /// <summary>
        /// 患者信息查询
        /// </summary>
        /// <param name="getMZPatientXML"></param>
        /// <returns></returns>
        [HttpGet("getMZPatient")]
        public string GetMZPatient(string getMZPatientXML)
        {
            if (string.IsNullOrWhiteSpace(getMZPatientXML))
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML不能为空"
                });
            }

            var getMZPatient = XMLHelper.DESerializer<GetMZPatient>(getMZPatientXML);
            if (getMZPatient == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML格式错误"
                });
            }

            if (getMZPatient.patCardType == 5 && string.IsNullOrWhiteSpace(getMZPatient.patName))
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "当诊疗卡类型为身份证时，患者姓名不能为空"
                });
            }

            var pt_Info = ptInfoBLL.GetPtInfoByCardNo(getMZPatient.patName, getMZPatient.patCardType, getMZPatient.patCardNo);
            if (pt_Info == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = 1,
                    resultMessage = "患者信息为空"
                });
            }

            SelfServiceMachine.Models.Response.getMZPatient getMZResponse = new getMZPatient
            {
                resultCode = 0,
                resultMessage = "",
                patType = 1,
                patName = pt_Info.pname,
                patSex = pt_Info.sex == "男" ? "M" : "F",
                patBirth = pt_Info.birth.ToString(),
                patAddress = pt_Info.addr1 + pt_Info.addr3,
                patMobile = pt_Info.tel,
                patIdType = CodeConvertUtils.GetIdNoType(pt_Info.idtype),
                patIdNo = pt_Info.idno,
                patCardType = getMZPatient.patCardType,
                patCardNo = getMZPatient.patCardNo,
                hasMedicare = !string.IsNullOrWhiteSpace(pt_Info.yno)
            };

            return XMLHelper.XmlSerialize(getMZPatient);
        }

        /// <summary>
        /// 首诊患者建档
        /// </summary>
        /// <param name="createACardXML"></param>
        /// <returns></returns>
        [HttpPost("createACard")]
        public string CreateACard(string createACardXML)
        {
            if (string.IsNullOrWhiteSpace(createACardXML))
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML不能为空"
                });
            }

            var createACard = XMLHelper.DESerializer<CreateACard>(createACardXML);
            if (createACard == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML格式错误"
                });
            }

            pt_info pt_Info = new pt_info()
            {
                pname = createACard.patName,
                sex = createACard.patSex == "M" ? "男" : "女",
                birth = Convert.ToDateTime(createACard.patBirth),
                addr1 = createACard.patAddress,
                tel = createACard.patMobile,
                ybidentity = createACard.patYbkh,
                yno = createACard.patDnh,
                patYbjbmc = createACard.patYbjbmc,
                patCblx = createACard.patCblx,
                idtype = CodeConvertUtils.GetIdNoType(createACard.patIdType),
                idno = createACard.patIdNo
            };

            var isAdd = ptInfoBLL.Add(pt_Info);
            if (isAdd != null)
            {
                return XMLHelper.XmlSerialize(new createACard()
                {
                    resultCode = 0,
                    resultMessage = "",
                    patCardType = createACard.patIdType,
                    patCardNo = createACard.patIdNo
                });
            }
            else
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = 99,
                    resultMessage = "建档失败"
                });
            }
        }

        /// <summary>
        /// 绑卡以及解绑
        /// </summary>
        /// <param name="bindCardXML"></param>
        /// <returns></returns>
        [HttpPost("bindCard")]
        public string BindCard(string bindCardXML)
        {
            if (string.IsNullOrWhiteSpace(bindCardXML))
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML不能为空"
                });
            }

            var bindCard = XMLHelper.DESerializer<BindCard>(bindCardXML);
            if (bindCard == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML格式错误"
                });
            }

            if (bindCard.bindType == "Y") //绑卡
            {
                var ptInfo = ptInfoBLL.GetInfoByCard(bindCard.PatId, bindCard.PatName);
                var card = cardInfoBLL.GetCardByCno(bindCard.patCardNo);
                if (card != null && card.pid != null)
                {
                    return XMLHelper.XmlSerialize(new BaseXMLModel()
                    {
                        resultCode = 99,
                        resultMessage = "卡号已绑定患者"
                    });
                }
                else
                {

                    if (ptInfo == null)
                    {
                        return XMLHelper.XmlSerialize(new BaseXMLModel()
                        {
                            resultCode = 99,
                            resultMessage = "患者信息为空"
                        });
                    }
                    cardInfoBLL.CreateCard(new card_info()
                    {
                        cno = bindCard.patCardNo.Trim(),
                        pid = ptInfo.pid,
                        cmoney = 0,
                        clevel = "银卡",
                        status = 0,
                        addperson = "自助机",
                        addtime = DateTime.Now,
                        del = false
                    });

                    return XMLHelper.XmlSerialize(new BaseXMLModel()
                    {
                        resultCode = 0,
                        resultMessage = ""
                    });
                }
            }
            else //解绑
            {
                var ptInfo = ptInfoBLL.GetInfoByCard(bindCard.PatId, bindCard.PatName);
                var card = cardInfoBLL.GetCardByCno(bindCard.patCardNo);

                if (ptInfo == null)
                {
                    return XMLHelper.XmlSerialize(new BaseXMLModel()
                    {
                        resultCode = 99,
                        resultMessage = "患者信息为空"
                    });
                }
                if (card == null || card.pid != ptInfo.pid)
                {
                    return XMLHelper.XmlSerialize(new BaseXMLModel()
                    {
                        resultCode = 99,
                        resultMessage = "卡号为空或卡号绑定其他患者"
                    });
                }

                card.pid = null;
                cardInfoBLL.UpdateCard(card);
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = 0,
                    resultMessage = ""
                });
            }
        }

        /// <summary>
        /// 就诊卡充值
        /// </summary>
        /// <param name="CardDepositXML"></param>
        /// <returns></returns>
        [HttpPost("CardDeposit")]
        public string CardDeposit(string CardDepositXML)
        {
            if (string.IsNullOrWhiteSpace(CardDepositXML))
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML不能为空"
                });
            }

            var CardDeposit = XMLHelper.DESerializer<Entity.SlefServiceModels.CardDeposit>(CardDepositXML);
            if (CardDeposit == null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "XML格式错误"
                });
            }

            var cardinfo = cardInfoBLL.GetCardByCno(CardDeposit.czkh);
            if (cardinfo == null && cardinfo.pid != null)
            {
                return XMLHelper.XmlSerialize(new BaseXMLModel()
                {
                    resultCode = -1,
                    resultMessage = "卡号为空"
                });
            }
            feeinfoBLL.DepositFeeinfo(Convert.ToInt32(cardinfo.pid), 0, Convert.ToDecimal(CardDeposit.czje), Convert.ToDecimal(CardDeposit.czje), 89757, "自助机", CardDeposit.czdsfdh, CardDeposit.type, out int feeid);
            var cardinfoDeposit = cardInfoBLL.CardDeposit(CardDeposit.czkh, CardDeposit.czrsfzh, CardDeposit.czrjzkhr, Convert.ToDecimal(CardDeposit.czje), CardDeposit.czdh, CardDeposit.czdsfdh, CardDeposit.xm, CardDeposit.type, feeid);

            if (cardinfoDeposit == null)
            {
                return XMLHelper.XmlSerialize(new Models.Response.CardDeposit()
                {
                    resultCode = 99,
                    resultMessage = "充值失败"
                });
            }
            else
            {
                return XMLHelper.XmlSerialize(new Models.Response.CardDeposit()
                {
                    resultCode = 0,
                    resultMessage = "",
                    czzh = cardinfoDeposit.cno,
                    czye = CardDeposit.czje,
                    czhzhye = cardinfoDeposit.cmoney.ToString()
                });
            }
        }
    }
}