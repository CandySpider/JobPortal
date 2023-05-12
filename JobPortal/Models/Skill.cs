﻿using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Skill
    {
        [Key] 
        public int SkillId { get; set; }

        [Required]
        public string SkillName { get; set; } = string.Empty;
        public ICollection<SkillSet>? SkillSets { get; set; }
    }
}
