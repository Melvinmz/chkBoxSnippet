using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chkBoxSnippet.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public class Skill
        {
            public int SkillID { get; set; }
            public string SkillName { get; set; }
        }
        [BindProperty]
        public IList<SelectListItem> Skills { get; set; }
        [TempData]
        public string SelectedSkills { get; set; }
        [TempData]
        public string SelectedSkillIDs { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            List<Skill> SkillList = new List<Skill>(){
             new Skill { SkillID = 1, SkillName = "Communication" },
            new Skill {SkillID = 2, SkillName = "Decision-Making" },
            new Skill {SkillID = 3, SkillName = "Flexibility" },
            new Skill {SkillID = 4, SkillName = "Innovation" },
            new Skill {SkillID = 5, SkillName = "Integrity" },
            new Skill {SkillID = 6, SkillName = "Leadership" },
            new Skill {SkillID = 7, SkillName = "Time Management" },
            new Skill {SkillID = 8, SkillName = "Negotiation" }
        };

            Skills = SkillList.ToList<Skill>().Select(m => new SelectListItem { Text = m.SkillName, Value = m.SkillID.ToString() }).ToList<SelectListItem>();
          
        }
        public IActionResult OnPost()
        {
            foreach (SelectListItem skill in Skills)
            {
                if (skill.Selected)
                {
                    SelectedSkills = $"{skill.Text},{SelectedSkills}";
                    SelectedSkillIDs= $"{skill.Value},{SelectedSkillIDs}";
                }
            }
            SelectedSkills = SelectedSkills.TrimEnd(',');
            SelectedSkillIDs = SelectedSkillIDs.TrimEnd(',');
            return RedirectToPage("index");            
        }
    }
}
