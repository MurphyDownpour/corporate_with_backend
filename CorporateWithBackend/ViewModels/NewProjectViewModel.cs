using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporateWithBackend.Models;

namespace CorporateWithBackend.ViewModels
{
    public class NewProjectViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}