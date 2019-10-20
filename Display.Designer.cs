namespace LinqLearning
{
    partial class Display
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.output = new System.Windows.Forms.TextBox();
            this.BtnUseIEnumerableInt = new System.Windows.Forms.Button();
            this.BtnUseIEnumerableString = new System.Windows.Forms.Button();
            this.BtnUseCsvFile = new System.Windows.Forms.Button();
            this.BtnMakeLinQExtensionMethod = new System.Windows.Forms.Button();
            this.BtnMakeLinQDataSourceClass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(215, 12);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output.Size = new System.Drawing.Size(1229, 712);
            this.output.TabIndex = 0;
            // 
            // BtnUseIEnumerableInt
            // 
            this.BtnUseIEnumerableInt.Location = new System.Drawing.Point(12, 12);
            this.BtnUseIEnumerableInt.Name = "BtnUseIEnumerableInt";
            this.BtnUseIEnumerableInt.Size = new System.Drawing.Size(195, 38);
            this.BtnUseIEnumerableInt.TabIndex = 1;
            this.BtnUseIEnumerableInt.Text = "UseIEnumerableInt";
            this.BtnUseIEnumerableInt.UseVisualStyleBackColor = true;
            this.BtnUseIEnumerableInt.Click += new System.EventHandler(this.BtnUseIEnumerableInt_Click);
            // 
            // BtnUseIEnumerableString
            // 
            this.BtnUseIEnumerableString.Location = new System.Drawing.Point(12, 56);
            this.BtnUseIEnumerableString.Name = "BtnUseIEnumerableString";
            this.BtnUseIEnumerableString.Size = new System.Drawing.Size(195, 38);
            this.BtnUseIEnumerableString.TabIndex = 2;
            this.BtnUseIEnumerableString.Text = "UseIEnumerableString";
            this.BtnUseIEnumerableString.UseVisualStyleBackColor = true;
            this.BtnUseIEnumerableString.Click += new System.EventHandler(this.BtnUseIEnumerableString_Click);
            // 
            // BtnUseCsvFile
            // 
            this.BtnUseCsvFile.Location = new System.Drawing.Point(12, 100);
            this.BtnUseCsvFile.Name = "BtnUseCsvFile";
            this.BtnUseCsvFile.Size = new System.Drawing.Size(195, 38);
            this.BtnUseCsvFile.TabIndex = 3;
            this.BtnUseCsvFile.Text = "UseCsvFile";
            this.BtnUseCsvFile.UseVisualStyleBackColor = true;
            this.BtnUseCsvFile.Click += new System.EventHandler(this.BtnUseCsvFile_Click);
            // 
            // BtnMakeLinQExtensionMethod
            // 
            this.BtnMakeLinQExtensionMethod.Location = new System.Drawing.Point(12, 144);
            this.BtnMakeLinQExtensionMethod.Name = "BtnMakeLinQExtensionMethod";
            this.BtnMakeLinQExtensionMethod.Size = new System.Drawing.Size(195, 38);
            this.BtnMakeLinQExtensionMethod.TabIndex = 4;
            this.BtnMakeLinQExtensionMethod.Text = "MakeLinQExtensionMethod";
            this.BtnMakeLinQExtensionMethod.UseVisualStyleBackColor = true;
            this.BtnMakeLinQExtensionMethod.Click += new System.EventHandler(this.BtnMakeLinQExtensionMethod_Click);
            // 
            // BtnMakeLinQDataSourceClass
            // 
            this.BtnMakeLinQDataSourceClass.Location = new System.Drawing.Point(12, 188);
            this.BtnMakeLinQDataSourceClass.Name = "BtnMakeLinQDataSourceClass";
            this.BtnMakeLinQDataSourceClass.Size = new System.Drawing.Size(195, 38);
            this.BtnMakeLinQDataSourceClass.TabIndex = 5;
            this.BtnMakeLinQDataSourceClass.Text = "MakeLinQDataSourceClass";
            this.BtnMakeLinQDataSourceClass.UseVisualStyleBackColor = true;
            this.BtnMakeLinQDataSourceClass.Click += new System.EventHandler(this.BtnMakeLinQDataSourceClass_Click);
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 727);
            this.Controls.Add(this.BtnMakeLinQDataSourceClass);
            this.Controls.Add(this.BtnMakeLinQExtensionMethod);
            this.Controls.Add(this.BtnUseCsvFile);
            this.Controls.Add(this.BtnUseIEnumerableString);
            this.Controls.Add(this.BtnUseIEnumerableInt);
            this.Controls.Add(this.output);
            this.Name = "Display";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button BtnUseIEnumerableInt;
        private System.Windows.Forms.Button BtnUseIEnumerableString;
        private System.Windows.Forms.Button BtnUseCsvFile;
        private System.Windows.Forms.Button BtnMakeLinQExtensionMethod;
        private System.Windows.Forms.Button BtnMakeLinQDataSourceClass;
    }
}

