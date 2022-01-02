using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using KEService.Models;
using KEService.Models.Data;

namespace KEService.Services
{
    public class PersonService
    {
        private BaseDAL objBaseDAL;
        string strQuery = "";
        private List<SqlParameter> lstParam;

        public List<PersonModel> GetPersonList()
        {
            objBaseDAL = new BaseDAL();


            List<PersonModel> lstPerson = new List<PersonModel>();

            try
            {
                lstParam = new List<SqlParameter>();
                strQuery = "SELECT * FROM person;";

                DataTable ResData = objBaseDAL.GetResultDataTable(strQuery, CommandType.Text, lstParam);

                foreach (DataRow dr in ResData.Rows)
                {
                    lstPerson.Add(
                        new PersonModel
                        {
                            Oid = Convert.ToString(dr["Oid"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            MiddleName = Convert.ToString(dr["MiddleName"]),
                            Birthday = Convert.ToString(dr["Birthday"]),
                            Email = Convert.ToString(dr["Email"]),
                        }
                        );
                }
            }
            catch (Exception ex)
            {
                CommonService.WriteErrorLog(ex);
            }

            return lstPerson;

        }

        public PersonModel GetPersonDataById(string Id)
        {
            objBaseDAL = new BaseDAL();


            PersonModel objPersonData = new PersonModel();


            try
            {
                strQuery = "SELECT * FROM person WHERE Oid = @Oid;";

                lstParam = new List<SqlParameter>();

                lstParam.AddRange(new SqlParameter[]
                      {
                                new SqlParameter("@Oid", Id)
                      });

                DataTable ResData = objBaseDAL.GetResultDataTable(strQuery, CommandType.Text, lstParam);
                DataRow dr = ResData.Rows[0];

                objPersonData = new PersonModel
                {
                    Oid = Convert.ToString(dr["Oid"]),
                    FirstName = Convert.ToString(dr["FirstName"]),
                    LastName = Convert.ToString(dr["LastName"]),
                    MiddleName = Convert.ToString(dr["MiddleName"]),
                    Birthday = Convert.ToString(dr["Birthday"]),
                    Email = Convert.ToString(dr["Email"]),
                };
            }
            catch (Exception ex)
            {
                CommonService.WriteErrorLog(ex);
            }

            return objPersonData;

        }
    }
}
