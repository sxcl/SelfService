﻿using SelfServiceMachine.Entity;
using SelfServiceMachine.Entity.SlefServiceModels;
using SelfServiceMachine.Service.IService;
using SelfServiceMachine.Service.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceMachine.Bussiness
{
    public class SysDeptBLL
    {
        private ISysDept iDept = new SysdeptService();

        public List<Entity.SResponse.GDeptItem> GetGDeptItems(string fCode)
        {
            return iDept.GetGDeptItems(fCode);
        }

        public sys_dept GetDeptByCode(string deptCode)
        {
            return iDept.Get(x => x.code == deptCode);
        }

        public string GetFloorByName(string dept)
        {
            return iDept.Get(x => x.name == dept).floor;
        }
    }
}
