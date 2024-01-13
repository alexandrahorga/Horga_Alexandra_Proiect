using System.Security.Policy;
using Horga_Alexandra_Proiect.Models;

namespace Horga_Alexandra_Proiect.Models.ViewModels
{
    public class DocIndexData
    {
        public IEnumerable<Doc> Docs { get; set; }
        public IEnumerable<Pacient> Pacienti { get; set; }
    }
}
