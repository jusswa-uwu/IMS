﻿namespace InventoryIMSSystemt
{
    partial class DashBoard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.AddNewCategoryBtn = new System.Windows.Forms.LinkLabel();
            this.dgvCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCategoryName});
            this.dataGridView1.Location = new System.Drawing.Point(180, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(782, 554);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(28, 245);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 35);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // AddNewCategoryBtn
            // 
            this.AddNewCategoryBtn.AutoSize = true;
            this.AddNewCategoryBtn.Location = new System.Drawing.Point(871, 63);
            this.AddNewCategoryBtn.Name = "AddNewCategoryBtn";
            this.AddNewCategoryBtn.Size = new System.Drawing.Size(92, 16);
            this.AddNewCategoryBtn.TabIndex = 4;
            this.AddNewCategoryBtn.TabStop = true;
            this.AddNewCategoryBtn.Text = "New Category";
            this.AddNewCategoryBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddNewCategoryBtn_LinkClicked);
            // 
            // dgvCategoryName
            // 
            this.dgvCategoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgvCategoryName.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategoryName.FillWeight = 102F;
            this.dgvCategoryName.HeaderText = "Category";
            this.dgvCategoryName.MinimumWidth = 6;
            this.dgvCategoryName.Name = "dgvCategoryName";
            this.dgvCategoryName.ReadOnly = true;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 688);
            this.Controls.Add(this.AddNewCategoryBtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DashBoard";
            this.Text = "DashBoard";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel AddNewCategoryBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCategoryName;
    }
}