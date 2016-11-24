namespace AssemblyCompiler
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_compilar = new System.Windows.Forms.Button();
            this.Input = new System.Windows.Forms.TextBox();
            this.Output = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.funct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hexa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Output)).BeginInit();
            this.SuspendLayout();
            // 
            // b_compilar
            // 
            this.b_compilar.Enabled = false;
            this.b_compilar.Location = new System.Drawing.Point(532, 180);
            this.b_compilar.Name = "b_compilar";
            this.b_compilar.Size = new System.Drawing.Size(128, 43);
            this.b_compilar.TabIndex = 0;
            this.b_compilar.Text = "Compilar";
            this.b_compilar.UseVisualStyleBackColor = true;
            this.b_compilar.Click += new System.EventHandler(this.b_compilar_Click);
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(12, 12);
            this.Input.Multiline = true;
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(649, 154);
            this.Input.TabIndex = 1;
            this.Input.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // Output
            // 
            this.Output.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Output.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.op,
            this.rs,
            this.rt,
            this.rd,
            this.shamt,
            this.funct,
            this.imm,
            this.addr,
            this.hexa});
            this.Output.Location = new System.Drawing.Point(12, 237);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(649, 304);
            this.Output.TabIndex = 4;
            // 
            // code
            // 
            this.code.HeaderText = "code";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // op
            // 
            this.op.HeaderText = "op";
            this.op.Name = "op";
            this.op.ReadOnly = true;
            // 
            // rs
            // 
            this.rs.HeaderText = "rs";
            this.rs.Name = "rs";
            this.rs.ReadOnly = true;
            // 
            // rt
            // 
            this.rt.HeaderText = "rt";
            this.rt.Name = "rt";
            this.rt.ReadOnly = true;
            // 
            // rd
            // 
            this.rd.HeaderText = "rd";
            this.rd.Name = "rd";
            this.rd.ReadOnly = true;
            // 
            // shamt
            // 
            this.shamt.HeaderText = "shamt";
            this.shamt.Name = "shamt";
            this.shamt.ReadOnly = true;
            // 
            // funct
            // 
            this.funct.HeaderText = "funct";
            this.funct.Name = "funct";
            this.funct.ReadOnly = true;
            // 
            // imm
            // 
            this.imm.HeaderText = "imm";
            this.imm.Name = "imm";
            this.imm.ReadOnly = true;
            // 
            // addr
            // 
            this.addr.HeaderText = "addr";
            this.addr.Name = "addr";
            this.addr.ReadOnly = true;
            // 
            // hexa
            // 
            this.hexa.HeaderText = "hexa";
            this.hexa.Name = "hexa";
            this.hexa.ReadOnly = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(678, 559);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.b_compilar);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Output)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button b_compilar;
        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.DataGridView Output;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn op;
        private System.Windows.Forms.DataGridViewTextBoxColumn rs;
        private System.Windows.Forms.DataGridViewTextBoxColumn rt;
        private System.Windows.Forms.DataGridViewTextBoxColumn rd;
        private System.Windows.Forms.DataGridViewTextBoxColumn shamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn funct;
        private System.Windows.Forms.DataGridViewTextBoxColumn imm;
        private System.Windows.Forms.DataGridViewTextBoxColumn addr;
        private System.Windows.Forms.DataGridViewTextBoxColumn hexa;
    }
}

