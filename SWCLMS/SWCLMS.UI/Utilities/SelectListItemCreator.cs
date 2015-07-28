using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWCLMS.Models.Tables;

namespace SWCLMS.UI.Utilities
{
    public static class SelectListItemCreator
    {
        public static List<SelectListItem> CreateFrom(List<GradeLevel> gradeLevels)
        {
            List<SelectListItem> list = new List<SelectListItem>(); 

            foreach (var level in gradeLevels)
            {
                list.Add(
                    new SelectListItem() {Text = level.GradeLevelName, Value = level.GradeLevelID.ToString()}
                    );
            }

            return list;

        }

    }
}