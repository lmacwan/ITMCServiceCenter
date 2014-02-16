using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.DLL
{
    public class ClientRepository
    {
       
        /// <summary>
        /// get list of all clients from database.
        /// </summary>
        /// <returns>returns list of all clients</returns>
        private static List<tbl_Client_DTO> GetAllClients()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                    from client in itmcContext.tbl_Client
                    select new tbl_Client_DTO()
                    {
                        Id = client.Id,
                        ContactNo = client.ContactNo,
                        Location = client.Location,
                        Name = client.Name
                    }).ToList();
                return result;
            }
        }

        /// <summary>
        /// get list of all clients from database.
        /// </summary>
        /// <returns>returns list of all clients</returns>
        public List<tbl_Client_DTO> GetClients()
        {
            return GetAllClients();
        }

        /// <summary>
        /// get client details based on Client Id from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_Client_DTO GetClient(int id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                    from client in itmcContext.tbl_Client
                    where client.Id == id
                    select new tbl_Client_DTO()
                    {
                        Id = client.Id,
                        ContactNo = client.ContactNo,
                        Location = client.Location,
                        Name = client.Name
                    }).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// save new client into the database.
        /// </summary>
        /// <param name="tbl_Client_DTO"></param>
        /// <returns>Return the number of records affected, i.e 1 if new client was inserted successfully else 0.</returns>
        public int SaveClient(tbl_Client_DTO tbl_Client_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                itmcContext.tbl_Client.Add(tbl_Client_DTO.ToEntity());
                var isSaved = itmcContext.SaveChanges() > 0;
                if (isSaved)
                {
                    //AllClients.Add(tbl_Client_DTO);
                    return tbl_Client_DTO.ToEntity().Id;
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// updates an existing client in database.
        /// </summary>
        /// <param name="tbl_Client_DTO"></param>
        /// <returns>return true if client was successfully updated otherwise false</returns>
        public bool UpdateClient(tbl_Client_DTO tbl_Client_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                itmcContext.Entry(tbl_Client_DTO.ToEntity()).State = System.Data.EntityState.Modified;
                return itmcContext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// deletes an existing client from database.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns>returns true if client was successfully deleted, otherwise false.</returns>
        public bool DeleteClient(int clientId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var client = itmcContext.tbl_Client.Find(clientId);
                itmcContext.tbl_Client.Remove(client);
                var isDeleted = itmcContext.SaveChanges() > 0;
                //if (isDeleted)
                //{
                //    AllClients.Remove(client.ToDTO());
                //}
                return isDeleted;
            }
        }
    }
}