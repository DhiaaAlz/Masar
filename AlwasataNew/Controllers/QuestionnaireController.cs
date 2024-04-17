using AlwasataNew.Data;
using AlwasataNew.Models;
using AlwasataNew.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AlwasataNew.Controllers
{
    
    public class QuestionnaireController : Controller
    {
        private readonly ApplicationDbContext _context;
        public QuestionnaireController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult QuestionnaireInteriorDesign()
        {
            var items = _context.InteriorDesignQuestionnaires.ToList();
            return View(items);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult InteriorDesign(int id,string? message)
        {
            if(id!=0)
            {
                var item = _context.InteriorDesignQuestionnaires.Where(x => x.Id == id).FirstOrDefault();
                var itemForModel = new InteriorDesignQuestionnaireVM();

                if (item != null)
                {
                    itemForModel.Id = item.Id;
                    itemForModel.PhoneNumber = item.PhoneNumber;
                    itemForModel.ClientName = item.ClientName;
                    itemForModel.Basment = item.Basment;
                    itemForModel.BuldingArea = item.BuldingArea;
                    itemForModel.DesignStyle = item.DesignStyle;
                    itemForModel.SurfaceFloor = item.SurfaceFloor;
                    itemForModel.ProjectType = item.ProjectType;

                    var firtFloor = _context.FirstFloorQuestionnaires.Where(x => x.InteriorDesignQuestionnaireId == id).FirstOrDefault();
                    var firstFloorQuestionnaire = new FirstFloorQuestionnaire();

                    firstFloorQuestionnaire.Id = firtFloor.Id;
                    firstFloorQuestionnaire.FirstFloorHall = firtFloor.FirstFloorHall;
                    firstFloorQuestionnaire.MasterBedroom = firtFloor.MasterBedroom;
                    firstFloorQuestionnaire.Room1 = firtFloor.Room1;
                    firstFloorQuestionnaire.Other = firtFloor.Other;
                    firstFloorQuestionnaire.InteriorDesignQuestionnaireId = firtFloor.InteriorDesignQuestionnaireId;

                    itemForModel.FirstFloorQuestionnaire = firstFloorQuestionnaire;
                    var groundFloor = _context.GroundFloorQuestionnaires.Where(x => x.InteriorDesignQuestionnaireId == id).FirstOrDefault();
                    var groundFloorQuestionnaire = new GroundFloorQuestionnaire();

                    groundFloorQuestionnaire.GroundFloorHall = groundFloor.GroundFloorHall;
                    groundFloorQuestionnaire.MenCouncil = groundFloor.MenCouncil;
                    groundFloorQuestionnaire.WomenCouncil = groundFloor.WomenCouncil;
                    groundFloorQuestionnaire.WCMenCouncil = groundFloor.WCMenCouncil;
                    groundFloorQuestionnaire.WCWomenCouncil = groundFloor.WCWomenCouncil;
                    groundFloorQuestionnaire.Kitchen = groundFloor.Kitchen;
                    groundFloorQuestionnaire.ExternalAttachment = groundFloor.ExternalAttachment;
                    groundFloorQuestionnaire.Other = groundFloor.Other;

                    itemForModel.GroundFloorQuestionnaire = groundFloor;

                    var interfaces = _context.Interfaces.Where(x => x.InteriorDesignQuestionnaireId == id).FirstOrDefault();
                    var itnterface = new Interfaces();

                    itnterface.FrontInterfaces = interfaces.FrontInterfaces;
                    itnterface.SideInterfaces = interfaces.SideInterfaces;
                    itnterface.SideInterfaces2 = interfaces.SideInterfaces2;
                    itnterface.BackInterfaces = interfaces.BackInterfaces;

                    itemForModel.Interfaces = itnterface;

                    if(message!=null && message!="")
                    {
                        ViewBag.message=message;
                    }
                    return View(itemForModel);

                }
                else
                {
                    return View(new InteriorDesignQuestionnaireVM());
                }
            }
            else
            {
                return View(new InteriorDesignQuestionnaireVM());
            }
            
            
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult InteriorDesign(InteriorDesignQuestionnaireVM model,string villa,
            string ResidentialBuilding, string CommercialBuilding, string institutionOffice, string institutionBuilding,
            string shop, string apartment,string projectTypeOtherInput, string modern, string classic, string newClassic,string OtherDesignStyle)
        {

            int RowId = 1;
            var rowCount = _context.InteriorDesignQuestionnaires.ToList().Count;
            if(rowCount>0)
            {
                RowId = rowCount+1;
            }

            var interiorDesignQuestionnaire = new InteriorDesignQuestionnaire();
         
            interiorDesignQuestionnaire.PhoneNumber = model.PhoneNumber;
            interiorDesignQuestionnaire.ClientName = model.ClientName;
            interiorDesignQuestionnaire.Basment= model.Basment;
            interiorDesignQuestionnaire.BuldingArea= model.BuldingArea;
            interiorDesignQuestionnaire.SurfaceFloor= model.SurfaceFloor;

            if(modern=="on")
            {
                interiorDesignQuestionnaire.DesignStyle = "موديرن";
            }
            else if(classic=="on")
            {
                interiorDesignQuestionnaire.DesignStyle = "كلاسيك";
            }
            else if(newClassic=="on") {
                interiorDesignQuestionnaire.DesignStyle = "نيو كلاسيك";
            }
            else
            {
                interiorDesignQuestionnaire.DesignStyle = OtherDesignStyle;
            }

            if(villa=="on")
            {
                interiorDesignQuestionnaire.ProjectType = "فيلا";
            }
            else if(ResidentialBuilding=="on")
            {
                interiorDesignQuestionnaire.ProjectType = "بناء سكني";
            }
            else if (CommercialBuilding == "on")
            {
                interiorDesignQuestionnaire.ProjectType = "بناء تجاري";
            }
            else if (institutionOffice == "on")
            {
                interiorDesignQuestionnaire.ProjectType = "مكتب اداري";
            }
            else if (institutionBuilding == "on")
            {
                interiorDesignQuestionnaire.ProjectType = "مبنى اداري";
            }
            else if (shop == "on")
            {
                interiorDesignQuestionnaire.ProjectType = "محل";
            }
            else if (apartment == "on")
            {
                interiorDesignQuestionnaire.ProjectType = "شقة";
            }
            else
            {
                interiorDesignQuestionnaire.ProjectType = projectTypeOtherInput;
            }

            interiorDesignQuestionnaire.FirstFloorQuestionnaireId = RowId;
            interiorDesignQuestionnaire.GroundFloorQuestionnaireId = RowId;
            interiorDesignQuestionnaire.InterfacesId = RowId;

            _context.InteriorDesignQuestionnaires.Add(interiorDesignQuestionnaire);
            _context.SaveChanges();


            var firstFloorQuestionnaire = new FirstFloorQuestionnaire();
            firstFloorQuestionnaire.InteriorDesignQuestionnaireId = RowId;
            firstFloorQuestionnaire.MasterBedroom = model.FirstFloorQuestionnaire.MasterBedroom;
            firstFloorQuestionnaire.FirstFloorHall = model.FirstFloorQuestionnaire.FirstFloorHall;
            firstFloorQuestionnaire.Room1 = model.FirstFloorQuestionnaire.Room1;
            firstFloorQuestionnaire.Other = model.FirstFloorQuestionnaire.Other;

            _context.FirstFloorQuestionnaires.Add(firstFloorQuestionnaire);
            _context.SaveChanges();

            var groundFloorQuestionnaire = new GroundFloorQuestionnaire();
            groundFloorQuestionnaire.MenCouncil = model.GroundFloorQuestionnaire.MenCouncil;
            groundFloorQuestionnaire.WomenCouncil = model.GroundFloorQuestionnaire.WomenCouncil;
            groundFloorQuestionnaire.WCMenCouncil = model.GroundFloorQuestionnaire.WCMenCouncil;
            groundFloorQuestionnaire.WCWomenCouncil = model.GroundFloorQuestionnaire.WCWomenCouncil;
            groundFloorQuestionnaire.GroundFloorHall = model.GroundFloorQuestionnaire.GroundFloorHall;
            groundFloorQuestionnaire.Kitchen = model.GroundFloorQuestionnaire.Kitchen;
            groundFloorQuestionnaire.ExternalAttachment = model.GroundFloorQuestionnaire.ExternalAttachment;
            groundFloorQuestionnaire.Other = model.GroundFloorQuestionnaire.Other;
            groundFloorQuestionnaire.InteriorDesignQuestionnaireId = RowId;
            _context.GroundFloorQuestionnaires.Add(groundFloorQuestionnaire);
            _context.SaveChanges();

            var interfaces = new Interfaces();
            interfaces.FrontInterfaces= model.Interfaces.FrontInterfaces;
            interfaces.SideInterfaces= model.Interfaces.SideInterfaces;
            interfaces.SideInterfaces2= model.Interfaces.SideInterfaces2;
            interfaces.BackInterfaces= model.Interfaces.BackInterfaces;
            interfaces.InteriorDesignQuestionnaireId= RowId;
            _context.Interfaces.Add(interfaces);
            _context.SaveChanges();


            ViewBag.message = "تم التقديم بنجاح";


            return RedirectToAction("InteriorDesign", new { id = RowId,message= "تم التقديم بنجاح" });
        }

        public IActionResult SentOfferPrice(int id)
        {
            var item = _context.InteriorDesignQuestionnaires.Where(x=>x.Id==id).FirstOrDefault();
            item.IsOfferPriceSent = true;
            _context.InteriorDesignQuestionnaires.Update(item);
            _context.SaveChanges();
            return RedirectToAction("QuestionnaireInteriorDesign");
        }
    }


   
}
