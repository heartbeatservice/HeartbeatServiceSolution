﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Data.Abstract;
using HBS.Entities;
using System.Data.SqlClient;
using System.Data;

namespace HBS.Data.Concrete
{
    public class AppointmentRepository : BaseRepository, IAppointmentRepository
    {
        private const string AddAppointmentSp = "AddAppointment";
        private const string UpdateAppointmentSp = "UpdateAppointment";
        private const string GetProfessionalAppointmentsSp = "GetProfessionalAppointments";
        private const string GetCustomerAppointmentsSp = "GetCustomerAppointments";


        int AddAppointment(Appointment appointment)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                //TODO: complete below
                using (var cmd = new SqlCommand(AddAppointmentSp, conn))
                {
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //cmd.Parameters.Add("@CompanyId", System.Data.SqlDbType.Int);
                    //cmd.Parameters["@CompanyId"].Value = appointment.;

                    //cmd.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar);
                    //cmd.Parameters["@UserName"].Value = appointment.UserName;

                    //cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar);
                    //cmd.Parameters["@Password"].Value = appointment.Password;

                    //cmd.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
                    //cmd.Parameters["@FirstName"].Value = appointment.FirstName;

                    //cmd.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
                    //cmd.Parameters["@LastName"].Value = appointment.LastName;

                 
                    cmd.Parameters.Add("@CreatedBy", System.Data.SqlDbType.Int);
                    cmd.Parameters["@CreatedBy"].Value = appointment.CreatedBy;

                    cmd.Parameters.Add("@CreatedDate", System.Data.SqlDbType.DateTime);
                    cmd.Parameters["@CreatedDate"].Value = DateTime.UtcNow;

                    return (int)cmd.ExecuteScalar();

                }
            }
        }

        bool UpdateAppointment(Appointment appointment)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                //TODO: complete below
                using (var cmd = new SqlCommand(UpdateAppointmentSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //cmd.Parameters.Add("@UserId", System.Data.SqlDbType.Int);
                    //cmd.Parameters["@UserId"].Value = appointment.UserId;

                    //cmd.Parameters.Add("@CompanyId", System.Data.SqlDbType.Int);
                    //cmd.Parameters["@CompanyId"].Value = appointment.CompanyId;

                    //cmd.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar);
                    //cmd.Parameters["@UserName"].Value = appointment.UserName;

                    //cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar);
                    //cmd.Parameters["@Password"].Value = appointment.Password;

                    //cmd.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
                    //cmd.Parameters["@FirstName"].Value = appointment.FirstName;

                    //cmd.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
                    //cmd.Parameters["@LastName"].Value = user.LastName;

                    //cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar);
                    //cmd.Parameters["@Email"].Value = user.Email;

                    cmd.Parameters.Add("@UpdatedBy", System.Data.SqlDbType.Int);
                    cmd.Parameters["@UpdatedBy"].Value = appointment.UpdatedBy;

                    cmd.Parameters.Add("@UpdatedDate", System.Data.SqlDbType.DateTime);
                    cmd.Parameters["@UpdatedDate"].Value = DateTime.UtcNow;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        List<Appointment> GetProfessionalAppointments(int professionalId, DateTime appointmentDate)
        {

            var appointment = new List<Appointment>();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetProfessionalAppointmentsSp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProfessionalId", SqlDbType.Int);
                    cmd.Parameters["@ProfessionalId"].Value = professionalId;
                    cmd.Parameters.Add("@AppointmentDate", SqlDbType.DateTime);
                    cmd.Parameters["@AppointmentDate"].Value = appointmentDate;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                appointment.Add(new Appointment(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return appointment;

            
           
        }


        List<Appointment> GetCustomerAppointments(int cusomterAppointments)
        {
            var appointment = new List<Appointment>();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetCustomerAppointmentsSp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CusomterAppointments", SqlDbType.Int);
                    cmd.Parameters["@CusomterAppointments"].Value = cusomterAppointments;
                 

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                appointment.Add(new Appointment(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return appointment;
           
        }
    }
}
