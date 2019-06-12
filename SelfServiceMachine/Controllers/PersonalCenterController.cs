using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NPinyin;
using SelfServiceMachine.Bussiness;
using SelfServiceMachine.Common;
using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Models.Request;
using SelfServiceMachine.Models.Response;
using SelfServiceMachine.Utils;

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
        /// <param name="getMZPatient"></param>
        /// <returns></returns>
        [HttpPost("getMZPatient")]
        public string GetMZPatient([FromBody]request<GetMZPatient> getMZPatient)
        {
            //if (string.IsNullOrWhiteSpace(getMZPatientXML))
            //{
            //    return RsXmlHelper.ResXml(-1, "XML不能为空");
            //}

            //var getMZPatient = XMLHelper.DESerializer<request<GetMZPatient>>(getMZPatientXML);
            if (getMZPatient == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            //if (getMZPatient.model.patCardType == 5 && string.IsNullOrWhiteSpace(getMZPatient.model.patName))
            //{
            //    return RsXmlHelper.ResXml(-1, "当诊疗卡类型为身份证时，患者姓名不能为空");
            //}

            var pt_Info = ptInfoBLL.GetPtInfoByCardNo(getMZPatient.model.patName, getMZPatient.model.patCardType, getMZPatient.model.patCardNo);
            if (pt_Info == null)
            {
                return RsXmlHelper.ResXml(1, "患者信息为空");
            }

            response<Entity.SResponse.getMZPatient> getMZResponse = new response<Entity.SResponse.getMZPatient>()
            {
                model = new Entity.SResponse.getMZPatient()
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
                    patCardType = getMZPatient.model.patCardType,
                    patCardNo = getMZPatient.model.patCardNo,
                    hasMedicare = !string.IsNullOrWhiteSpace(pt_Info.yno)
                }
            };

            return XMLHelper.XmlSerialize(getMZResponse);
        }

        /// <summary>
        /// 首诊患者建档
        /// </summary>
        /// <param name="createACard"></param>
        /// <returns></returns>
        [HttpPost("createACard")]
        public string CreateACard([FromBody]request<CreateACard> createACard)
        {
            if (createACard == null)
            {
                return RsXmlHelper.ResXml("-1", "XML格式错误");
            }
            var ptInfo = ptInfoBLL.GetPt_Info(x => x.idno == createACard.model.patIdNo);
            if (ptInfo != null)
            {
                return RsXmlHelper.ResXml("1", "患者信息已存在");
            }

            pt_info pt_Info = null;
            if (!string.IsNullOrWhiteSpace(createACard.model.patYbkh) && !string.IsNullOrWhiteSpace(createACard.model.patDnh) && !string.IsNullOrWhiteSpace(createACard.model.patYbjbmc) && !string.IsNullOrWhiteSpace(createACard.model.patCblx))
            {
                pt_Info = new pt_info()
                {
                    pname = createACard.model.patName,
                    sex = createACard.model.patSex == "M" ? "男" : "女",
                    birth = Convert.ToDateTime(createACard.model.patBirth),
                    addr1 = createACard.model.patAddress,
                    tel = createACard.model.patMobile,
                    ybidentity = createACard.model.patYbjbmc,
                    yno = createACard.model.patDnh,
                    patYbjbmc = createACard.model.patYbjbmc,
                    patCblx = createACard.model.patCblx,
                    idtype = CodeConvertUtils.GetIdNoType(Convert.ToInt32(createACard.model.patIdType)),
                    idno = createACard.model.patIdNo,
                    addtime = DateTime.Now,
                    del = false,
                    pinyin = Pinyin.GetInitials(createACard.model.patName).ToLower(),
                    memo = "患者通过自助机建档",
                    addperson = "自助机"
                };
            }
            else
            {
                pt_Info = new pt_info()
                {
                    pname = createACard.model.patName,
                    sex = createACard.model.patSex == "M" ? "男" : "女",
                    birth = Convert.ToDateTime(createACard.model.patBirth),
                    addr1 = createACard.model.patAddress,
                    tel = createACard.model.patMobile,
                    idtype = CodeConvertUtils.GetIdNoType(Convert.ToInt32(createACard.model.patIdType)),
                    idno = createACard.model.patIdNo,
                    addtime = DateTime.Now,
                    del = false,
                    pinyin = Pinyin.GetInitials(createACard.model.patName).ToLower(),
                    memo = "患者通过自助机建档",
                    addperson = "自助机"
                };
            }

            var isAdd = ptInfoBLL.Add(pt_Info);
            if (isAdd != null)
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.createACard>()
                {
                    model = new Entity.SResponse.createACard()
                    {
                        resultCode = "0",
                        resultMessage = "",
                        patCardType = createACard.model.patIdType,
                        patCardNo = createACard.model.patIdNo
                    }
                });
            }
            else
            {
                return RsXmlHelper.ResXml("99", "建档失败");
            }
        }

        /// <summary>
        /// 绑卡以及解绑
        /// </summary>
        /// <param name="bindCard"></param>
        /// <returns></returns>
        [HttpPost("bindCard")]
        public string BindCard([FromBody]request<BindCard> bindCard)
        {
            //if (string.IsNullOrWhiteSpace(bindCardXML))
            //{
            //    return RsXmlHelper.ResXml(-1, "XML不能为空");
            //}

            //var bindCard = XMLHelper.DESerializer<request<BindCard>>(bindCardXML);
            if (bindCard == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            if (bindCard.model.bindType == "Y") //绑卡
            {
                var ptInfo = ptInfoBLL.GetInfoByCard(bindCard.model.PatId, bindCard.model.PatName);
                var card = cardInfoBLL.GetCardByCno(bindCard.model.patCardNo);

                card_info existCard = null;

                if (card != null && card.pid != null)
                {
                    if (card.pid == ptInfo.pid)
                    {
                        return RsXmlHelper.ResXml(0, JsonOperator.JsonSerialize(card));
                    }
                    else
                    {
                        return RsXmlHelper.ResXml(99, "卡号已绑定患者");
                    }
                }
                else if (card != null && card.pid == null)
                {
                    card.pid = ptInfo.pid;
                    cardInfoBLL.UpdateCard(card);

                    ptInfo.cno = card.cno.Trim();
                    ptInfoBLL.Update(ptInfo);

                    return RsXmlHelper.ResXml(0, "");
                }
                else
                {
                    if (ptInfo == null)
                    {
                        return RsXmlHelper.ResXml(99, "患者信息为空");
                    }

                    if (!string.IsNullOrWhiteSpace(ptInfo.cno))
                    {
                        existCard = cardInfoBLL.GetCardByCno(ptInfo.cno);
                    }

                    if (existCard == null)
                    {
                        cardInfoBLL.CreateCard(new card_info()
                        {
                            cno = bindCard.model.patCardNo.Trim(),
                            pid = ptInfo.pid,
                            cmoney = 0,
                            clevel = "银卡",
                            status = 0,
                            addperson = "自助机",
                            addtime = DateTime.Now,
                            del = false
                        });

                        ptInfo.cno = bindCard.model.patCardNo.Trim();
                        ptInfoBLL.Update(ptInfo);

                        return RsXmlHelper.ResXml(0, "");
                    }
                    else
                    {
                        return RsXmlHelper.ResXml(0, JsonOperator.JsonSerialize(existCard));
                    }
                }
            }
            else if (bindCard.model.bindType == "S")
            {
                var ptInfo = ptInfoBLL.GetInfoByCard(bindCard.model.PatId, bindCard.model.PatName);
                if (ptInfo == null)
                {
                    return RsXmlHelper.ResXml(99, "患者信息为空");
                }
                if (!string.IsNullOrWhiteSpace(ptInfo.cno))
                {
                    return RsXmlHelper.ResXml(0, "患者已绑定就诊卡");
                }
                else
                {
                    return RsXmlHelper.ResXml(1, "患者未绑定就诊卡");
                }
            }
            else //解绑
            {
                var ptInfo = ptInfoBLL.GetInfoByCard(bindCard.model.PatId, bindCard.model.PatName);

                card_info card = null;
                if (!string.IsNullOrWhiteSpace(bindCard.model.patCardNo))
                {
                    card = cardInfoBLL.GetCardByCno(bindCard.model.patCardNo);
                }
                else
                {
                    var cardList = cardInfoBLL.GetByPid(ptInfo.pid);
                    if (cardList != null && cardList.Count > 1)
                    {
                        return RsXmlHelper.ResXml(99, "患者绑定多张卡");
                    }
                    card = cardList.FirstOrDefault();
                }

                if (ptInfo == null)
                {
                    return RsXmlHelper.ResXml(99, "患者信息为空");
                }
                if (card == null || card.pid != ptInfo.pid)
                {
                    return RsXmlHelper.ResXml(99, "卡号为空或卡号绑定其他患者");
                }

                ptInfo.cno = null;
                ptInfoBLL.Update(ptInfo);

                card.pid = null;
                cardInfoBLL.UpdateCard(card);
                return RsXmlHelper.ResXml(0, "");
            }
        }

        /// <summary>
        /// 就诊卡充值
        /// </summary>
        /// <param name="CardDeposit"></param>
        /// <returns></returns>
        [HttpPost("CardDeposit")]
        public string CardDeposit([FromBody]request<Entity.SlefServiceModels.CardDeposit> CardDeposit)
        {
            if (CardDeposit == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var cardinfo = cardInfoBLL.GetCardByCno(CardDeposit.model.czkh);
            if (cardinfo == null && cardinfo.pid != null)
            {
                return RsXmlHelper.ResXml(-1, "卡号为空");
            }
            var pt_Info = ptInfoBLL.GetPt_Info(x => x.pid == cardinfo.pid);
            if (pt_Info == null)
            {
                return RsXmlHelper.ResXml(-1, "患者信息为空");
            }

            feeinfoBLL.DepositFeeinfo(Convert.ToInt32(cardinfo.pid), 0, Convert.ToDecimal(CardDeposit.model.czje), Convert.ToDecimal(CardDeposit.model.czje), 89757, "自助机", CardDeposit.model.czkh, CardDeposit.model.type, out int feeid);
            var cardinfoDeposit = cardInfoBLL.CardDeposit(CardDeposit.model.czkh, CardDeposit.model.czrsfzh, CardDeposit.model.czrjzkhr, Convert.ToDecimal(CardDeposit.model.czje), CardDeposit.model.czdh, CardDeposit.model.czdsfdh, CardDeposit.model.xm, CardDeposit.model.type, feeid);


            if (cardinfoDeposit == null)
            {
                return RsXmlHelper.ResXml(99, "充值失败");
            }
            else
            {
                return XMLHelper.XmlSerialize(new response<Entity.SResponse.cardDeposit>()
                {
                    model = new Entity.SResponse.cardDeposit()
                    {
                        resultCode = 0,
                        resultMessage = "",
                        czzh = cardinfoDeposit.cno,
                        czye = CardDeposit.model.czje,
                        czhzhye = cardinfoDeposit.cmoney.ToString(),
                        name = pt_Info.pname,
                        idcard = pt_Info.idno
                    }
                });
            }
        }

        /// <summary>
        /// 获取会员卡信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("memberinfo")]
        public string MembershipCardInfo(request<Entity.SRequest.MemberShipInfo> memberShipInfo)
        {
            if (memberShipInfo == null)
            {
                return RsXmlHelper.ResXml(-1, "XML格式错误");
            }

            var cardInfo = cardInfoBLL.GetCardByCno(memberShipInfo.model.czkh);
            if (cardInfo == null)
            {
                return RsXmlHelper.ResXml(-1, "卡号信息不存在");
            }
            else if (cardInfo.pid == null || cardInfo.pid == 0 || cardInfo.del == true)
            {
                return RsXmlHelper.ResXml(99, "该卡暂未绑定患者");
            }

            var ptInfo = ptInfoBLL.GetPt_Info(x => x.pid == cardInfo.pid);
            if (ptInfo == null || ptInfo.del == true)
            {
                return RsXmlHelper.ResXml(-1, "患者信息已被删除");
            }

            return XMLHelper.XmlSerialize(new response<Entity.SResponse.MemberShipInfo>()
            {
                model = new Entity.SResponse.MemberShipInfo()
                {
                    ResultCode = 0,
                    ResultMessage = "",
                    Idcardh = ptInfo.idno,
                    Name = ptInfo.pname,
                    Sex = ptInfo.sex == "男" ? "M" : "F",
                    Ye = Convert.ToDecimal(cardInfo.cmoney * 100),
                }
            });
        }
    }
}