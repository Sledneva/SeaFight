namespace SeaFight
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridPlayer = new System.Windows.Forms.DataGridView();
            this.enemyGrid = new System.Windows.Forms.DataGridView();
            this.label_Stage = new System.Windows.Forms.Label();
            this.label_NextShipSize = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_GeneretaRandom = new System.Windows.Forms.Button();
            this.radioButton_Vertical = new System.Windows.Forms.RadioButton();
            this.radioButton_Horizontal = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPlayer
            // 
            this.gridPlayer.AllowUserToAddRows = false;
            this.gridPlayer.AllowUserToDeleteRows = false;
            this.gridPlayer.AllowUserToResizeColumns = false;
            this.gridPlayer.AllowUserToResizeRows = false;
            this.gridPlayer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPlayer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.gridPlayer.Location = new System.Drawing.Point(240, 12);
            this.gridPlayer.MultiSelect = false;
            this.gridPlayer.Name = "gridPlayer";
            this.gridPlayer.ReadOnly = true;
            this.gridPlayer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gridPlayer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridPlayer.Size = new System.Drawing.Size(266, 242);
            this.gridPlayer.TabIndex = 3;
            this.gridPlayer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPlayer_CellClick);
            // 
            // enemyGrid
            // 
            this.enemyGrid.AllowUserToAddRows = false;
            this.enemyGrid.AllowUserToDeleteRows = false;
            this.enemyGrid.AllowUserToResizeColumns = false;
            this.enemyGrid.AllowUserToResizeRows = false;
            this.enemyGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.enemyGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.enemyGrid.Location = new System.Drawing.Point(550, 12);
            this.enemyGrid.MultiSelect = false;
            this.enemyGrid.Name = "enemyGrid";
            this.enemyGrid.ReadOnly = true;
            this.enemyGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.enemyGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.enemyGrid.Size = new System.Drawing.Size(266, 242);
            this.enemyGrid.TabIndex = 4;
            this.enemyGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.enemyGrid_CellClick);
            // 
            // label_Stage
            // 
            this.label_Stage.AutoSize = true;
            this.label_Stage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Stage.Location = new System.Drawing.Point(12, 12);
            this.label_Stage.Name = "label_Stage";
            this.label_Stage.Size = new System.Drawing.Size(213, 24);
            this.label_Stage.TabIndex = 5;
            this.label_Stage.Text = "Расстановка кораблей";
            // 
            // label_NextShipSize
            // 
            this.label_NextShipSize.AutoSize = true;
            this.label_NextShipSize.Location = new System.Drawing.Point(20, 16);
            this.label_NextShipSize.Name = "label_NextShipSize";
            this.label_NextShipSize.Size = new System.Drawing.Size(13, 13);
            this.label_NextShipSize.TabIndex = 6;
            this.label_NextShipSize.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_GeneretaRandom);
            this.groupBox1.Controls.Add(this.radioButton_Vertical);
            this.groupBox1.Controls.Add(this.radioButton_Horizontal);
            this.groupBox1.Controls.Add(this.label_NextShipSize);
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 119);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Позиция";
            // 
            // button_GeneretaRandom
            // 
            this.button_GeneretaRandom.Location = new System.Drawing.Point(23, 90);
            this.button_GeneretaRandom.Name = "button_GeneretaRandom";
            this.button_GeneretaRandom.Size = new System.Drawing.Size(75, 23);
            this.button_GeneretaRandom.TabIndex = 11;
            this.button_GeneretaRandom.Text = "Случайно";
            this.button_GeneretaRandom.UseVisualStyleBackColor = true;
            this.button_GeneretaRandom.Click += new System.EventHandler(this.button_GeneretaRandom_Click);
            // 
            // radioButton_Vertical
            // 
            this.radioButton_Vertical.AutoSize = true;
            this.radioButton_Vertical.Location = new System.Drawing.Point(14, 54);
            this.radioButton_Vertical.Name = "radioButton_Vertical";
            this.radioButton_Vertical.Size = new System.Drawing.Size(91, 17);
            this.radioButton_Vertical.TabIndex = 1;
            this.radioButton_Vertical.TabStop = true;
            this.radioButton_Vertical.Text = "Вертикально";
            this.radioButton_Vertical.UseVisualStyleBackColor = true;
            // 
            // radioButton_Horizontal
            // 
            this.radioButton_Horizontal.AutoSize = true;
            this.radioButton_Horizontal.Checked = true;
            this.radioButton_Horizontal.Location = new System.Drawing.Point(14, 38);
            this.radioButton_Horizontal.Name = "radioButton_Horizontal";
            this.radioButton_Horizontal.Size = new System.Drawing.Size(102, 17);
            this.radioButton_Horizontal.TabIndex = 0;
            this.radioButton_Horizontal.TabStop = true;
            this.radioButton_Horizontal.Text = "Горизонтально\r\n";
            this.radioButton_Horizontal.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(35, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Начать игру";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 282);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_Stage);
            this.Controls.Add(this.enemyGrid);
            this.Controls.Add(this.gridPlayer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView gridPlayer;
        private System.Windows.Forms.DataGridView enemyGrid;
        private System.Windows.Forms.Label label_Stage;
        private System.Windows.Forms.Label label_NextShipSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_Vertical;
        private System.Windows.Forms.RadioButton radioButton_Horizontal;
        private System.Windows.Forms.Button button_GeneretaRandom;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

