using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class MsCodeRepository
    {
        public static List<MsCodeModel> GetAll()
        {
            List<MsCodeModel> modellist = new List<MsCodeModel>()
            {
                new MsCodeModel{
                    Id=1001,
                    Name = "Rudra",
                    Details ="Software Developer"
            },
            new MsCodeModel{
                    Id=1002,
                    Name = "Sonu Singh",
                    Details ="Software Developer"
            }
            };
            return modellist;
        }
        public static MsCodeModel GetOne(int id)
        {
            return MsCodeRepository.GetAll().Where(x => x.Id.Equals(id)).SingleOrDefault();
        }
        public static void UpdateData(int id, MsCodeModel model)
        {
            var data = MsCodeRepository.GetAll().Where(x => x.Id.Equals(id)).SingleOrDefault();
            data.Name = model.Name;
            data.Details = model.Details;
            //do update on server
        }
        public static MsCodeModel DeleteData(int id)
        {
            return MsCodeRepository.GetAll().Where(x => x.Id.Equals(id)).SingleOrDefault();
        }
    }
}