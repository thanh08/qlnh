using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhahang.DTO
{
    public class Billinfo
    {
        public Billinfo(int id,int idbill,int idmonan,int count)
        {
            this.Id = id;
            this.Idbill = idbill;
            this.Idmonan = idmonan;
            this.count = count;
        }
        public Billinfo(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Idbill = (int)row["idbill"];
            this.Idmonan = (int)row["idmonan"];
            this.count = (int)row["count"];

        }
        private int count;
        private int idmonan;
        private int idbill;
        private int id;

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

        public int Idbill
        {
            get
            {
                return idbill;
            }

            set
            {
                idbill = value;
            }
        }

        public int Idmonan
        {
            get
            {
                return idmonan;
            }

            set
            {
                idmonan = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }
    }
}
