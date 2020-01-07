namespace GiexpertLib
{
    partial class GiExpertAx
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GiExpertAx));
            this.axGiExpertControl1 = new AxGIEXPERTCONTROLLib.AxGiExpertControl();
            ((System.ComponentModel.ISupportInitialize)(this.axGiExpertControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axGiExpertControl1
            // 
            this.axGiExpertControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axGiExpertControl1.Enabled = true;
            this.axGiExpertControl1.Location = new System.Drawing.Point(182, 121);
            this.axGiExpertControl1.Name = "axGiExpertControl1";
            this.axGiExpertControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGiExpertControl1.OcxState")));
            this.axGiExpertControl1.Size = new System.Drawing.Size(150, 150);
            this.axGiExpertControl1.TabIndex = 0;
            // 
            // GiExpertAx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axGiExpertControl1);
            this.Name = "GiExpertAx";
            ((System.ComponentModel.ISupportInitialize)(this.axGiExpertControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxGIEXPERTCONTROLLib.AxGiExpertControl axGiExpertControl1;
    }
}
