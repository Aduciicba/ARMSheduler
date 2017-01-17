namespace ARMSchedulerApp
{
    partial class fmMain
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
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpEventLog = new DevExpress.XtraTab.XtraTabPage();
            this.gcEventsLog = new DevExpress.XtraGrid.GridControl();
            this.gvEventsLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.tpSettings = new DevExpress.XtraTab.XtraTabPage();
            this.btnSaveSettings = new DevExpress.XtraEditors.SimpleButton();
            this.gcMailSettings = new DevExpress.XtraEditors.GroupControl();
            this.btnTestMail = new DevExpress.XtraEditors.SimpleButton();
            this.teMailPassword = new System.Windows.Forms.MaskedTextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.teMailServer = new DevExpress.XtraEditors.TextEdit();
            this.teMailServerPort = new DevExpress.XtraEditors.TextEdit();
            this.teMailLogin = new DevExpress.XtraEditors.TextEdit();
            this.teEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.beImportDirPath = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.beArmDbPath = new DevExpress.XtraEditors.ButtonEdit();
            this.tpImport = new DevExpress.XtraTab.XtraTabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveImport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.btnDelImportEmail = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditImportEmail = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddImportEmail = new DevExpress.XtraEditors.SimpleButton();
            this.lbImportEmails = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.teFileNameMask = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.teImportTime = new DevExpress.XtraEditors.TimeEdit();
            this.wdImportWeekDays = new DevExpress.XtraScheduler.UI.WeekDaysCheckEdit();
            this.tpMail = new DevExpress.XtraTab.XtraTabPage();
            this.btnSaveMail = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.btnDelMailEmail = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditMailEmail = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddMailEmail = new DevExpress.XtraEditors.SimpleButton();
            this.lbMailEmails = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.teMailTime = new DevExpress.XtraEditors.TimeEdit();
            this.wdMailWeekDays = new DevExpress.XtraScheduler.UI.WeekDaysCheckEdit();
            this.tpClose = new DevExpress.XtraTab.XtraTabPage();
            this.ofdDbPath = new System.Windows.Forms.OpenFileDialog();
            this.fbdImportDir = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpEventLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEventsLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEventsLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.tpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMailSettings)).BeginInit();
            this.gcMailSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teMailServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMailServerPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMailLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beImportDirPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beArmDbPath.Properties)).BeginInit();
            this.tpImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbImportEmails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFileNameMask.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teImportTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wdImportWeekDays)).BeginInit();
            this.tpMail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbMailEmails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMailTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wdMailWeekDays)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.tcMain.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpEventLog;
            this.tcMain.Size = new System.Drawing.Size(672, 421);
            this.tcMain.TabIndex = 0;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpEventLog,
            this.tpSettings,
            this.tpImport,
            this.tpMail,
            this.tpClose});
            this.tcMain.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tcMain_SelectedPageChanged);
            this.tcMain.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.tcMain_SelectedPageChanging);
            // 
            // tpEventLog
            // 
            this.tpEventLog.Controls.Add(this.gcEventsLog);
            this.tpEventLog.Name = "tpEventLog";
            this.tpEventLog.Size = new System.Drawing.Size(532, 415);
            this.tpEventLog.Text = "Лог событий";
            // 
            // gcEventsLog
            // 
            this.gcEventsLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEventsLog.Location = new System.Drawing.Point(0, 0);
            this.gcEventsLog.MainView = this.gvEventsLog;
            this.gcEventsLog.Name = "gcEventsLog";
            this.gcEventsLog.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEdit2});
            this.gcEventsLog.Size = new System.Drawing.Size(532, 415);
            this.gcEventsLog.TabIndex = 0;
            this.gcEventsLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEventsLog});
            // 
            // gvEventsLog
            // 
            this.gvEventsLog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5});
            this.gvEventsLog.GridControl = this.gcEventsLog;
            this.gvEventsLog.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gvEventsLog.Name = "gvEventsLog";
            this.gvEventsLog.OptionsBehavior.Editable = false;
            this.gvEventsLog.OptionsBehavior.ReadOnly = true;
            this.gvEventsLog.OptionsView.RowAutoHeight = true;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn6.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn6.Caption = "Событие";
            this.gridColumn6.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn6.FieldName = "event_type_name";
            this.gridColumn6.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 130;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "Время события";
            this.gridColumn2.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "event_time";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 125;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "Статус";
            this.gridColumn4.FieldName = "event_state";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 125;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn5.Caption = "Сообщение";
            this.gridColumn5.ColumnEdit = this.repositoryItemMemoEdit2;
            this.gridColumn5.FieldName = "event_errors";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 132;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.btnSaveSettings);
            this.tpSettings.Controls.Add(this.gcMailSettings);
            this.tpSettings.Controls.Add(this.labelControl2);
            this.tpSettings.Controls.Add(this.beImportDirPath);
            this.tpSettings.Controls.Add(this.labelControl1);
            this.tpSettings.Controls.Add(this.beArmDbPath);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Size = new System.Drawing.Size(532, 415);
            this.tpSettings.Text = "Общие настройки";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.Location = new System.Drawing.Point(414, 385);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(111, 23);
            this.btnSaveSettings.TabIndex = 14;
            this.btnSaveSettings.Text = "Сохранить";
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // gcMailSettings
            // 
            this.gcMailSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcMailSettings.Controls.Add(this.btnTestMail);
            this.gcMailSettings.Controls.Add(this.teMailPassword);
            this.gcMailSettings.Controls.Add(this.labelControl7);
            this.gcMailSettings.Controls.Add(this.labelControl6);
            this.gcMailSettings.Controls.Add(this.labelControl5);
            this.gcMailSettings.Controls.Add(this.labelControl4);
            this.gcMailSettings.Controls.Add(this.teMailServer);
            this.gcMailSettings.Controls.Add(this.teMailServerPort);
            this.gcMailSettings.Controls.Add(this.teMailLogin);
            this.gcMailSettings.Controls.Add(this.teEmail);
            this.gcMailSettings.Controls.Add(this.labelControl3);
            this.gcMailSettings.Location = new System.Drawing.Point(12, 130);
            this.gcMailSettings.Name = "gcMailSettings";
            this.gcMailSettings.Size = new System.Drawing.Size(513, 249);
            this.gcMailSettings.TabIndex = 4;
            this.gcMailSettings.Text = "Настройки электронной почты";
            // 
            // btnTestMail
            // 
            this.btnTestMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestMail.Location = new System.Drawing.Point(7, 221);
            this.btnTestMail.Name = "btnTestMail";
            this.btnTestMail.Size = new System.Drawing.Size(125, 23);
            this.btnTestMail.TabIndex = 13;
            this.btnTestMail.Text = "Проверить отправку";
            this.btnTestMail.Click += new System.EventHandler(this.btnTestMail_Click);
            // 
            // teMailPassword
            // 
            this.teMailPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teMailPassword.Location = new System.Drawing.Point(220, 146);
            this.teMailPassword.Name = "teMailPassword";
            this.teMailPassword.PasswordChar = '*';
            this.teMailPassword.Size = new System.Drawing.Size(288, 20);
            this.teMailPassword.TabIndex = 12;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(7, 149);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(41, 13);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "Пароль:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(7, 120);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(97, 13);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Имя пользователя:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(7, 91);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(207, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Номер порта сервера исходящей почты:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 62);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(174, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Адрес сервера исходящей почты:";
            // 
            // teMailServer
            // 
            this.teMailServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teMailServer.Location = new System.Drawing.Point(220, 59);
            this.teMailServer.Name = "teMailServer";
            this.teMailServer.Size = new System.Drawing.Size(288, 20);
            this.teMailServer.TabIndex = 7;
            // 
            // teMailServerPort
            // 
            this.teMailServerPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teMailServerPort.Location = new System.Drawing.Point(220, 88);
            this.teMailServerPort.Name = "teMailServerPort";
            this.teMailServerPort.Size = new System.Drawing.Size(288, 20);
            this.teMailServerPort.TabIndex = 6;
            // 
            // teMailLogin
            // 
            this.teMailLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teMailLogin.Location = new System.Drawing.Point(220, 117);
            this.teMailLogin.Name = "teMailLogin";
            this.teMailLogin.Size = new System.Drawing.Size(288, 20);
            this.teMailLogin.TabIndex = 5;
            // 
            // teEmail
            // 
            this.teEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teEmail.Location = new System.Drawing.Point(220, 30);
            this.teEmail.Name = "teEmail";
            this.teEmail.Size = new System.Drawing.Size(288, 20);
            this.teEmail.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(7, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(138, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Адрес электронной почты:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(211, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Путь к каталогу с данными для импорта:";
            // 
            // beImportDirPath
            // 
            this.beImportDirPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.beImportDirPath.Location = new System.Drawing.Point(12, 92);
            this.beImportDirPath.Name = "beImportDirPath";
            this.beImportDirPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beImportDirPath.Size = new System.Drawing.Size(513, 20);
            this.beImportDirPath.TabIndex = 2;
            this.beImportDirPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beImportDirPath_ButtonClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(204, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Путь к базе данных комплекта АРМ ОТ:";
            // 
            // beArmDbPath
            // 
            this.beArmDbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.beArmDbPath.Location = new System.Drawing.Point(12, 33);
            this.beArmDbPath.Name = "beArmDbPath";
            this.beArmDbPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beArmDbPath.Size = new System.Drawing.Size(513, 20);
            this.beArmDbPath.TabIndex = 0;
            this.beArmDbPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beArmDbPath_ButtonClick);
            // 
            // tpImport
            // 
            this.tpImport.Controls.Add(this.panel1);
            this.tpImport.Controls.Add(this.btnSaveImport);
            this.tpImport.Controls.Add(this.labelControl11);
            this.tpImport.Controls.Add(this.btnDelImportEmail);
            this.tpImport.Controls.Add(this.btnEditImportEmail);
            this.tpImport.Controls.Add(this.btnAddImportEmail);
            this.tpImport.Controls.Add(this.lbImportEmails);
            this.tpImport.Controls.Add(this.labelControl10);
            this.tpImport.Controls.Add(this.labelControl9);
            this.tpImport.Controls.Add(this.teFileNameMask);
            this.tpImport.Controls.Add(this.labelControl8);
            this.tpImport.Controls.Add(this.teImportTime);
            this.tpImport.Controls.Add(this.wdImportWeekDays);
            this.tpImport.Name = "tpImport";
            this.tpImport.Size = new System.Drawing.Size(532, 415);
            this.tpImport.Text = "Импорт данных";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(450, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(37, 31);
            this.panel1.TabIndex = 26;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // btnSaveImport
            // 
            this.btnSaveImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveImport.Location = new System.Drawing.Point(414, 385);
            this.btnSaveImport.Name = "btnSaveImport";
            this.btnSaveImport.Size = new System.Drawing.Size(111, 23);
            this.btnSaveImport.TabIndex = 25;
            this.btnSaveImport.Text = "Сохранить";
            this.btnSaveImport.Click += new System.EventHandler(this.btnSaveImport_Click);
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(12, 9);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(162, 13);
            this.labelControl11.TabIndex = 12;
            this.labelControl11.Text = "Настройка параметров импорта";
            // 
            // btnDelImportEmail
            // 
            this.btnDelImportEmail.Location = new System.Drawing.Point(450, 269);
            this.btnDelImportEmail.Name = "btnDelImportEmail";
            this.btnDelImportEmail.Size = new System.Drawing.Size(75, 23);
            this.btnDelImportEmail.TabIndex = 11;
            this.btnDelImportEmail.Text = "Удалить";
            this.btnDelImportEmail.Click += new System.EventHandler(this.btnDelImportEmail_Click);
            // 
            // btnEditImportEmail
            // 
            this.btnEditImportEmail.Location = new System.Drawing.Point(450, 240);
            this.btnEditImportEmail.Name = "btnEditImportEmail";
            this.btnEditImportEmail.Size = new System.Drawing.Size(75, 23);
            this.btnEditImportEmail.TabIndex = 10;
            this.btnEditImportEmail.Text = "Изменить";
            this.btnEditImportEmail.Click += new System.EventHandler(this.btnEditImportEmail_Click);
            // 
            // btnAddImportEmail
            // 
            this.btnAddImportEmail.Location = new System.Drawing.Point(450, 211);
            this.btnAddImportEmail.Name = "btnAddImportEmail";
            this.btnAddImportEmail.Size = new System.Drawing.Size(75, 23);
            this.btnAddImportEmail.TabIndex = 9;
            this.btnAddImportEmail.Text = "Добавить";
            this.btnAddImportEmail.Click += new System.EventHandler(this.btnAddImportEmail_Click);
            // 
            // lbImportEmails
            // 
            this.lbImportEmails.Location = new System.Drawing.Point(12, 211);
            this.lbImportEmails.Name = "lbImportEmails";
            this.lbImportEmails.Size = new System.Drawing.Size(432, 168);
            this.lbImportEmails.TabIndex = 8;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(12, 186);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(351, 13);
            this.labelControl10.TabIndex = 7;
            this.labelControl10.Text = "Отправить отчет после завершения импорта на следующие адреса:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 154);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(79, 13);
            this.labelControl9.TabIndex = 6;
            this.labelControl9.Text = "Время импорта:";
            // 
            // teFileNameMask
            // 
            this.teFileNameMask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teFileNameMask.EditValue = "*_imp.csv";
            this.teFileNameMask.Location = new System.Drawing.Point(188, 40);
            this.teFileNameMask.Name = "teFileNameMask";
            this.teFileNameMask.Size = new System.Drawing.Size(337, 20);
            this.teFileNameMask.TabIndex = 5;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 43);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(170, 13);
            this.labelControl8.TabIndex = 4;
            this.labelControl8.Text = "Маска имени файла для импорта:";
            // 
            // teImportTime
            // 
            this.teImportTime.EditValue = new System.DateTime(2015, 12, 21, 0, 0, 0, 0);
            this.teImportTime.Location = new System.Drawing.Point(98, 151);
            this.teImportTime.Name = "teImportTime";
            this.teImportTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.teImportTime.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.teImportTime.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.teImportTime.Size = new System.Drawing.Size(100, 20);
            this.teImportTime.TabIndex = 1;
            // 
            // wdImportWeekDays
            // 
            this.wdImportWeekDays.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wdImportWeekDays.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wdImportWeekDays.Appearance.Options.UseBackColor = true;
            this.wdImportWeekDays.Location = new System.Drawing.Point(13, 84);
            this.wdImportWeekDays.Name = "wdImportWeekDays";
            this.wdImportWeekDays.Size = new System.Drawing.Size(502, 61);
            this.wdImportWeekDays.TabIndex = 0;
            // 
            // tpMail
            // 
            this.tpMail.Controls.Add(this.btnSaveMail);
            this.tpMail.Controls.Add(this.labelControl12);
            this.tpMail.Controls.Add(this.btnDelMailEmail);
            this.tpMail.Controls.Add(this.btnEditMailEmail);
            this.tpMail.Controls.Add(this.btnAddMailEmail);
            this.tpMail.Controls.Add(this.lbMailEmails);
            this.tpMail.Controls.Add(this.labelControl13);
            this.tpMail.Controls.Add(this.labelControl14);
            this.tpMail.Controls.Add(this.teMailTime);
            this.tpMail.Controls.Add(this.wdMailWeekDays);
            this.tpMail.Name = "tpMail";
            this.tpMail.Size = new System.Drawing.Size(532, 415);
            this.tpMail.Text = "Отправка уведомлений";
            // 
            // btnSaveMail
            // 
            this.btnSaveMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMail.Location = new System.Drawing.Point(414, 385);
            this.btnSaveMail.Name = "btnSaveMail";
            this.btnSaveMail.Size = new System.Drawing.Size(111, 23);
            this.btnSaveMail.TabIndex = 24;
            this.btnSaveMail.Text = "Сохранить";
            this.btnSaveMail.Click += new System.EventHandler(this.btnSaveMail_Click);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(13, 10);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(238, 13);
            this.labelControl12.TabIndex = 23;
            this.labelControl12.Text = "Настройка параметров рассылки уведомлений";
            // 
            // btnDelMailEmail
            // 
            this.btnDelMailEmail.Location = new System.Drawing.Point(450, 222);
            this.btnDelMailEmail.Name = "btnDelMailEmail";
            this.btnDelMailEmail.Size = new System.Drawing.Size(75, 23);
            this.btnDelMailEmail.TabIndex = 22;
            this.btnDelMailEmail.Text = "Удалить";
            this.btnDelMailEmail.Click += new System.EventHandler(this.btnDelMailEmail_Click);
            // 
            // btnEditMailEmail
            // 
            this.btnEditMailEmail.Location = new System.Drawing.Point(450, 193);
            this.btnEditMailEmail.Name = "btnEditMailEmail";
            this.btnEditMailEmail.Size = new System.Drawing.Size(75, 23);
            this.btnEditMailEmail.TabIndex = 21;
            this.btnEditMailEmail.Text = "Изменить";
            this.btnEditMailEmail.Click += new System.EventHandler(this.btnEditMailEmail_Click);
            // 
            // btnAddMailEmail
            // 
            this.btnAddMailEmail.Location = new System.Drawing.Point(450, 164);
            this.btnAddMailEmail.Name = "btnAddMailEmail";
            this.btnAddMailEmail.Size = new System.Drawing.Size(75, 23);
            this.btnAddMailEmail.TabIndex = 20;
            this.btnAddMailEmail.Text = "Добавить";
            this.btnAddMailEmail.Click += new System.EventHandler(this.btnAddMailEmail_Click);
            // 
            // lbMailEmails
            // 
            this.lbMailEmails.Location = new System.Drawing.Point(13, 164);
            this.lbMailEmails.Name = "lbMailEmails";
            this.lbMailEmails.Size = new System.Drawing.Size(431, 215);
            this.lbMailEmails.TabIndex = 19;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(13, 139);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(220, 13);
            this.labelControl13.TabIndex = 18;
            this.labelControl13.Text = "Отправить рассылку уведомлений адреса:";
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(13, 107);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(85, 13);
            this.labelControl14.TabIndex = 17;
            this.labelControl14.Text = "Время рассылки:";
            // 
            // teMailTime
            // 
            this.teMailTime.EditValue = new System.DateTime(2015, 12, 21, 0, 0, 0, 0);
            this.teMailTime.Location = new System.Drawing.Point(104, 104);
            this.teMailTime.Name = "teMailTime";
            this.teMailTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.teMailTime.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.teMailTime.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.teMailTime.Size = new System.Drawing.Size(100, 20);
            this.teMailTime.TabIndex = 14;
            // 
            // wdMailWeekDays
            // 
            this.wdMailWeekDays.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wdMailWeekDays.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.wdMailWeekDays.Appearance.Options.UseBackColor = true;
            this.wdMailWeekDays.Location = new System.Drawing.Point(14, 37);
            this.wdMailWeekDays.Name = "wdMailWeekDays";
            this.wdMailWeekDays.Size = new System.Drawing.Size(502, 61);
            this.wdMailWeekDays.TabIndex = 13;
            // 
            // tpClose
            // 
            this.tpClose.Name = "tpClose";
            this.tpClose.Size = new System.Drawing.Size(532, 415);
            this.tpClose.Text = "Закрыть программу";
            // 
            // ofdDbPath
            // 
            this.ofdDbPath.FileName = "openFileDialog1";
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 421);
            this.Controls.Add(this.tcMain);
            this.MaximumSize = new System.Drawing.Size(1069, 633);
            this.MinimumSize = new System.Drawing.Size(682, 430);
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ARM Scheduler";
            this.Load += new System.EventHandler(this.fmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpEventLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEventsLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEventsLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMailSettings)).EndInit();
            this.gcMailSettings.ResumeLayout(false);
            this.gcMailSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teMailServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMailServerPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMailLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beImportDirPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beArmDbPath.Properties)).EndInit();
            this.tpImport.ResumeLayout(false);
            this.tpImport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbImportEmails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFileNameMask.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teImportTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wdImportWeekDays)).EndInit();
            this.tpMail.ResumeLayout(false);
            this.tpMail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbMailEmails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMailTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wdMailWeekDays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpEventLog;
        private DevExpress.XtraTab.XtraTabPage tpSettings;
        private DevExpress.XtraTab.XtraTabPage tpImport;
        private DevExpress.XtraTab.XtraTabPage tpMail;
        private DevExpress.XtraGrid.GridControl gcEventsLog;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEventsLog;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnSaveSettings;
        private DevExpress.XtraEditors.GroupControl gcMailSettings;
        private DevExpress.XtraEditors.SimpleButton btnTestMail;
        private System.Windows.Forms.MaskedTextBox teMailPassword;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit teMailServer;
        private DevExpress.XtraEditors.TextEdit teMailServerPort;
        private DevExpress.XtraEditors.TextEdit teMailLogin;
        private DevExpress.XtraEditors.TextEdit teEmail;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit beImportDirPath;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit beArmDbPath;
        private System.Windows.Forms.OpenFileDialog ofdDbPath;
        private System.Windows.Forms.FolderBrowserDialog fbdImportDir;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit teFileNameMask;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TimeEdit teImportTime;
        private DevExpress.XtraScheduler.UI.WeekDaysCheckEdit wdImportWeekDays;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.SimpleButton btnDelImportEmail;
        private DevExpress.XtraEditors.SimpleButton btnEditImportEmail;
        private DevExpress.XtraEditors.SimpleButton btnAddImportEmail;
        private DevExpress.XtraEditors.ListBoxControl lbImportEmails;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SimpleButton btnDelMailEmail;
        private DevExpress.XtraEditors.SimpleButton btnEditMailEmail;
        private DevExpress.XtraEditors.SimpleButton btnAddMailEmail;
        private DevExpress.XtraEditors.ListBoxControl lbMailEmails;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.TimeEdit teMailTime;
        private DevExpress.XtraScheduler.UI.WeekDaysCheckEdit wdMailWeekDays;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraEditors.SimpleButton btnSaveImport;
        private DevExpress.XtraEditors.SimpleButton btnSaveMail;
        private DevExpress.XtraTab.XtraTabPage tpClose;
        private System.Windows.Forms.Panel panel1;

    }
}

