using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckin, DateTime? datecheckout, int status)
        {
            this.Id = id;
            this.Datecheckin = datecheckin;
            this.Datecheckout = datecheckin;
            this.Status = status;
        }
        public Bill(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Datecheckin = (DateTime?)row["datecheckin"];
            var datecheckouttemp = row["datecheckout"];
            if(datecheckouttemp.ToString() != "")
            this.Datecheckout = (DateTime?)datecheckouttemp;
            this.Status = (int)row["status"];
        }
        private int status;
        private DateTime? datecheckout;
        private DateTime? datecheckin;
        private int id;

        public DateTime? Datecheckin
        {
            get
            {
                return datecheckin;
            }

            set
            {
                datecheckin = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public DateTime? Datecheckout
        {
            get
            {
                return datecheckout;
            }

            set
            {
                datecheckout = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
    }
}
