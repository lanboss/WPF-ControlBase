﻿using HeBianGu.Control.PropertyGrid;
using HeBianGu.Systems.Repository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace HeBianGu.App.Repository
{
    public class hi_dd_author : IndentifyEntityBase
    {
        public hi_dd_author()
        {
            Name = "默认权限";
        }
        [Required]
        [Display(Name = "权限名称")]
        [RegularExpression(@"^[\u4e00-\u9fa5]{0,}$", ErrorMessage = "只能输入汉字！")]
        [Column("author_name", Order = 1)]
        public string Name { get; set; }

        [Display(Name = "权限编码")]
        [Column("author_code", Order = 2)]
        public string AuthorCode { get; set; }

        [XmlIgnore]
        [Display(Name = "角色列表")]
        [Property(Type = typeof(MultiSelectRepositoryPropertyItem))]
        public ICollection<hi_dd_role> Roles { get; set; }
    }
}
