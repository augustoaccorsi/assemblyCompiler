using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblyCompiler
{
    public partial class Form1 : Form
    {
        bool error = false;
        string posiJ = string.Empty;
        string jota = string.Empty;
        bool label2 = false;

        public Form1()
        {
            InitializeComponent();
        }

        private AssembyItem add(string rd, string rs, string rt, string code)
        {
            AssembyItem result = new AssembyItem("000000", registrator(rs), registrator(rt), registrator(rd), "00000", "100000", code);
            return result;
        }

        private AssembyItem addi(string rt, string rs, int imm, string code)
        {
            string number = Convert.ToString(imm, 2);

            if (number.Length < 16 || number.Length > 16)
                number = get16bits(number);

            AssembyItem result = new AssembyItem("001000", registrator(rs), registrator(rt), number, code);
            return result;
        }

        private AssembyItem sub(string rd, string rs, string rt, string code)
        {
            AssembyItem result = new AssembyItem("000000", registrator(rs), registrator(rt), registrator(rd), "00000", "100010", code);
            return result;
        }

        private AssembyItem and(string rd, string rs, string rt, string code)
        {
            AssembyItem result = new AssembyItem("100100", registrator(rs), registrator(rt), registrator(rd), "00000", "100101", code);
            return result;
        }

        private AssembyItem andi(string rt, string rs, int imm, string code)
        {
            string number = Convert.ToString(imm, 2);

            if (number.Length < 16 || number.Length > 16)
                number = get16bits(number);

            AssembyItem result = new AssembyItem("001100", registrator(rs), registrator(rt), number, code);
            return result;
        }

        private AssembyItem or(string rd, string rs, string rt, string code)
        {
            AssembyItem result = new AssembyItem("000000", registrator(rs), registrator(rt), registrator(rd), "00000", "100101", code);
            return result;
        }

        private AssembyItem ori(string rt, string rs, int imm, string code)
        {
            string number = Convert.ToString(imm, 2);

            if (number.Length < 16 || number.Length > 16)
                number = get16bits(number);

            AssembyItem result = new AssembyItem("001101", registrator(rs), registrator(rt), number, code);
            return result;
        }

        private AssembyItem slt(string rd, string rs, string rt, string code)
        {
            AssembyItem result = new AssembyItem("000000", registrator(rs), registrator(rt), registrator(rd), "00000", "101010", code);
            return result;
        }

        private AssembyItem slti(string rt, string rs, int imm, string code)
        {
            string number = Convert.ToString(imm, 2);

            if (number.Length < 16 || number.Length > 16)
                number = get16bits(number);

            AssembyItem result = new AssembyItem("001010", registrator(rs), registrator(rt), number, code);
            return result;
        }

        private AssembyItem beq(string rt, string rs, int imm, string code)
        {
            string number = Convert.ToString(imm, 2);

            if (number.Length < 16 || number.Length > 16)
                number = get16bits(number);

            AssembyItem result = new AssembyItem("000100", registrator(rs), registrator(rt), number, code);
            return result;
        }

        private AssembyItem lw(string rt, string rs, string code)
        {
            string[] value = rs.Split('(');
            string str = value[1].Replace(")", "");

            int imm = Convert.ToInt32(value[0]);

            string number = Convert.ToString(imm, 2);

            if (number.Length < 16 || number.Length > 16)
                number = get16bits(number);

            AssembyItem result = new AssembyItem("100011", registrator(str), registrator(rt), number, code);

            return result;
        }

        private AssembyItem sw(string rt, string rs, string code)
        {
            string[] value = rs.Split('(');
            string str = value[1].Replace(")", "");

            int imm = Convert.ToInt32(value[0]);

            string number = Convert.ToString(imm, 2);

            if (number.Length < 16 || number.Length > 16)
                number = get16bits(number);

            AssembyItem result = new AssembyItem("101011", registrator(str), registrator(rt), number, code);

            return result;
        }

        private AssembyItem j(string label, string[] str, string code, int pos)
        {
            if (pos.ToString() == posiJ)
                return null;

            for (int i = pos + 1; i < str.Length; i++)
            {
                if (str[i].Contains(label))
                {
                    jota = label;
                    label2 = true;
                    string address = Convert.ToString(i * 4, 2);
                    if (address.Length < 26 || address.Length > 26)
                        address = get26bits(address);
                    return new AssembyItem("000010", address, code);
                }
            }
            error = true;
            return null;
        }

        private string registrator(string a)
        {
            switch (a)
            {
                case "$0": //0
                    return "00000";
                case "$s0": //16
                    return "10000";
                case "$s1": //17
                    return "10001";
                case "$s2": //18
                    return "10010";
                case "$s3": //19
                    return "10011";
                case "$s4": //20
                    return "10100";
                case "$s5": //21
                    return "10101";
                case "$s6": //22
                    return "10110";
                case "$s7": //23
                    return "10111";
                case "$t0": //8
                    return "01000";
                case "$t1": //9
                    return "01001";
                case "$t2": //10
                    return "01010";
                case "$t3": //11
                    return "01011";
                case "$t4": //12
                    return "01100";
                case "$t5": //13
                    return "01101";
                case "$t6": //14
                    return "01110";
                case "$t7": //15
                    return "01111";
                case "$t8": //24
                    return "11000";
                case "$t9": //25
                    return "11001";
                default:
                    error = true;
                    return "";
            }
        }

        private string get16bits(string number) //transform binary in 16bits binary
        {
            if (number.Length < 16)
                while (number.Length != 16)
                    number = 0 + number;
            else
                while (number.Length != 16)
                    number = number.Remove(0, 1);
            return number;
        }

        private string get26bits(string number) //transform binary in 26bits binary
        {
            if (number.Length < 26)
                while (number.Length != 26)
                    number = 0 + number;
            else
                while (number.Length != 26)
                    number = number.Remove(0, 1);
            return number;
        }


        private void readAssemby(string text)
        {
            string[] aux = new String[100000];
            aux = text.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);


            for (int lin = 0; lin < aux.Length; lin++)
            {
                string code = aux[lin];

                aux[lin] = (aux[lin].Replace(",", ""));

                while (aux[lin].EndsWith(" "))
                    aux[lin] = aux[lin].Substring(0, aux[lin].Length - 1);

                string[] aux2 = new String[5];
                aux2 = aux[lin].Split(' ');

                if (aux2.Length > 4)
                {
                    addToTableError(code);
                    error = false;
                }
                else
                {
                    switch (aux2[0].ToLower())
                    {
                        case "add":
                            try
                            {
                                AssembyItem res = add(aux2[1], aux2[2], aux2[3], code);
                                if (!error)
                                    addToTable(res, "r");
                                else
                                {
                                    addToTableError(code);
                                    error = false;
                                }
                            }
                            catch (Exception e)
                            {
                                addToTableError(code);
                            }
                            break;
                        case "addi":
                            try
                            {
                                AssembyItem res = addi(aux2[1], aux2[2], Convert.ToInt16(aux2[3]), code);
                                if (!error)
                                    addToTable(res, "i");
                                else
                                {
                                    addToTableError(code);
                                    error = false;
                                }
                            }
                            catch (Exception e)
                            {
                                addToTableError(code);
                            }
                            break;
                        case "sub":
                            try
                            {
                                AssembyItem res = sub(aux2[1], aux2[2], aux2[3], code);
                                if (!error)
                                    addToTable(res, "r");
                                else
                                {
                                    addToTableError(code);
                                    error = false;
                                }
                            }
                            catch (Exception e)
                            {
                                addToTableError(code);
                            }
                            break;
                        case "and":
                            try
                            {
                                AssembyItem res = and(aux2[1], aux2[2], aux2[3], code);
                                if (!error)
                                    addToTable(res, "r");
                                else
                                {
                                    addToTableError(code);
                                    error = false;
                                }
                            }
                            catch (Exception e)
                            {
                                addToTableError(code);
                            }
                            break;
                        case "andi":
                            try
                            {
                                AssembyItem res = andi(aux2[1], aux2[2], Convert.ToInt16(aux2[3]), code);
                                if (!error)
                                    addToTable(res, "i");
                                else
                                {
                                    addToTableError(code);
                                    error = false;
                                }
                            }
                            catch (Exception e)
                            {
                                addToTableError(code);
                            }
                            break;
                        case "or":
                            try
                            {
                                AssembyItem res = or(aux2[1], aux2[2], aux2[3], code);
                                if (!error)
                                    addToTable(res, "r");
                                else
                                {
                                    addToTableError(code);
                                    error = false;
                                }
                            }
                            catch (Exception e)
                            {
                                addToTableError(code);
                            }
                            break;
                        case "ori":
                            try
                            {
                                AssembyItem res = ori(aux2[1], aux2[2], Convert.ToInt16(aux2[3]), code);
                                if (!error)
                                    addToTable(res, "i");
                                else
                                {
                                    addToTableError(code);
                                    error = false;
                                }
                            }
                            catch (Exception e)
                            {
                                addToTableError(code);
                            }
                            break;
                        case "beq":
                            try
                            {
                                AssembyItem res = beq(aux2[1], aux2[2], Convert.ToInt16(aux2[3]), code);
                                if (!error)
                                    addToTable(res, "i");
                                else
                                {
                                    addToTableError(code);
                                    error = false;
                                }
                            }
                            catch (Exception e)
                            {
                                addToTableError(code);
                            }
                            break;
                        case "slt":
                            try
                            {
                                AssembyItem res = slt(aux2[1], aux2[2], aux2[3], code);
                                if (!error)
                                    addToTable(res, "r");
                                else
                                {
                                    addToTableError(code);
                                    error = false;
                                }
                            }
                            catch (Exception e)
                            {
                                addToTableError(code);
                            }
                            break;
                        case "slti":
                            try
                            {
                                AssembyItem res = slti(aux2[1], aux2[2], Convert.ToInt16(aux2[3]), code);
                                if (!error)
                                    addToTable(res, "i");
                                else
                                {
                                    addToTableError(code);
                                    error = false;
                                }
                            }
                            catch (Exception e)
                            {
                                addToTableError(code);
                            }
                            break;
                        case "j":
                            try
                            {
                                AssembyItem res = j(aux2[1], aux, code, lin);
                                if (!error)
                                {
                                    if (res != null)
                                        addToTable(res, "j");
                                }
                                else
                                {
                                    addToTableError(code);
                                    error = false;
                                }

                            }
                            catch (Exception e)
                            {
                                addToTableError(code);
                            }
                            break;
                        case "lw":
                            try
                            {
                                AssembyItem res = lw(aux2[1], aux2[2], code);
                                if (!error)
                                    addToTable(res, "i");
                                else
                                {
                                    addToTableError(code);
                                    error = false;
                                }
                            }
                            catch (Exception e)
                            {
                                addToTableError(code);
                            }
                            break;
                        case "sw":
                            try
                            {
                                AssembyItem res = sw(aux2[1], aux2[2], code);
                                if (!error)
                                    addToTable(res, "i");
                                else
                                {
                                    addToTableError(code);
                                    error = false;
                                }
                                break;
                            }
                            catch (Exception e)
                            {
                                addToTableError(code);
                            }
                            break;
                        default:
                            if (label2 && code == jota)
                                label2 = false;
                            else
                                addToTableError(code);
                            break;
                    }
                }
            }
        }

        private void addToTable(AssembyItem res, string type)
        {
            if (type == "i")
                Output.Rows.Add(res.code, res.op, res.rs, res.rt, "", "", "", res.imm, "", res.hexa);
            else if (type == "r")
                Output.Rows.Add(res.code, res.op, res.rs, res.rt, res.rd, res.shamt, res.funct, "", "", res.hexa);
            else if (type == "j")
                Output.Rows.Add(res.code, res.op, "", "", "", "", "", "", res.addr, res.hexa);
        }

        private void addToTableError(string code)
        {
            Output.Rows.Add(code, "ERRO", "ERRO", "ERRO", "ERRO", "ERRO", "ERRO", "ERRO", "ERRO", "ERRO");
            Int32 index = Output.Rows.Count - 2;
            Output.Rows[index].DefaultCellStyle.BackColor = Color.Red;
        }

        private void b_compilar_Click(object sender, EventArgs e)
        {
            Output.DataSource = null;
            Output.Rows.Clear();
            readAssemby(Input.Text);
            string a = "a, b";
            a = a.Replace(',', ' ');
            string[] aux = a.Split(' ');
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            b_compilar.Enabled = true;
        }
    }
}
