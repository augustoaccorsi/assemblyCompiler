using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyCompiler
{
    public class AssembyItem
    {
        public string op { get; set; }
        public string rs { get; set; }
        public string rt { get; set; }
        public string rd { get; set; }
        public string shamt { get; set; }
        public string funct { get; set; }
        public string addr { get; set; }
        public string imm { get; set; }
        public string hexa { get; set; }
        public string binary { get; set; }
        public string code { get; set; }

        public AssembyItem(string op, string rs, string rt, string rd, string shamt, string funct, string code)
        {
            this.op = op;
            this.rs = rs;
            this.rt = rt;
            this.rd = rd;
            this.shamt = shamt;
            this.funct = funct;
            this.code = code;
            this.binary = op + rs + rt + rd + shamt + funct;
            this.hexa = "0x" + Convert.ToInt64(binary, 2).ToString("X");
        }

        public AssembyItem(string op, string rs, string rt, string imm, string code)
        {
            this.op = op;
            this.rs = rs;
            this.rt = rt;
            this.imm = imm;
            this.code = code;
            this.binary = op + rs + rt + imm;
            this.hexa = "0x" + Convert.ToInt64(binary, 2).ToString("X");
        }

        public AssembyItem(string op, string addr, string code)
        {
            this.op = op;
            this.addr = addr;
            this.code = code;
            this.binary = op + addr;
            this.hexa = "0x" + Convert.ToInt64(binary, 2).ToString("X");
        }
    }
}
