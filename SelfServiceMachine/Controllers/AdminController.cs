using Microsoft.AspNetCore.Mvc;
using SelfServiceMachine.Entity;

namespace SelfServiceMachine.Controllers
{
    /// <summary>
    /// 管理员控制器
    /// </summary>
    //[Route("api/[controller]")]
    //[ApiController]
    public class AdminController : ControllerBase
    {

        /// <summary>
        /// 根据id获取患者信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}"), ProducesResponseType(typeof(pt_info), 200)]
        public pt_info GetPt_InfoById(int id)
        {
            switch (id)
            {
                case 1:
                    return new pt_info()
                    {
                        pid = 1,
                        pname = "王"
                    };
                default:
                    return new pt_info()
                    {
                        pid = 2,
                        pname = "王"
                    };
            }
        }
    }
}