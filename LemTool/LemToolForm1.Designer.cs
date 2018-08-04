namespace LemTool
{
  partial class LemToolForm1
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.gradientBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.gradientBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // gradientBox1
      // 
      this.gradientBox1.Location = new System.Drawing.Point(12, 12);
      this.gradientBox1.Name = "gradientBox1";
      this.gradientBox1.Size = new System.Drawing.Size(1024, 50);
      this.gradientBox1.TabIndex = 0;
      this.gradientBox1.TabStop = false;
      // 
      // LemToolForm1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
      this.ClientSize = new System.Drawing.Size(1235, 660);
      this.Controls.Add(this.gradientBox1);
      this.Name = "LemToolForm1";
      this.Text = "Lementoids Tool";
      this.Shown += new System.EventHandler(this.LemToolForm1_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.gradientBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox gradientBox1;
  }
}

