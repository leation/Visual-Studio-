using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Windows.Forms;

namespace Leation.VSAddin
{
	/// <summary>用于实现外接程序的对象。</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2, IDTCommandTarget
	{
        private DTE2 _app;
        private AddIn _addIn;

        /// <summary>实现外接程序对象的构造函数。请将您的初始化代码置于此方法内。</summary>
		public Connect()
		{
		}

		/// <summary>实现 IDTExtensibility2 接口的 OnConnection 方法。接收正在加载外接程序的通知。</summary>
		/// <param term='application'>宿主应用程序的根对象。</param>
		/// <param term='connectMode'>描述外接程序的加载方式。</param>
		/// <param term='addInInst'>表示此外接程序的对象。</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		{            
            _app = (DTE2)application;
			_addIn = (AddIn)addInInst;

            if (connectMode == ext_ConnectMode.ext_cm_UISetup||connectMode== ext_ConnectMode.ext_cm_AfterStartup||connectMode== ext_ConnectMode.ext_cm_Startup)
            {
                object[] contextGUIDS = new object[] { };
                Commands2 commands = (Commands2)_app.Commands;

                Microsoft.VisualStudio.CommandBars.CommandBar menuBarCommandBar = ((Microsoft.VisualStudio.CommandBars.CommandBars)_app.CommandBars)["MenuBar"];

                CommandBarControl cmdCtr = this.GetExistCommandBarControl(menuBarCommandBar, "李仙伟");
                if (cmdCtr != null)
                {
                    cmdCtr.Visible = true;
                    return;
                }
                CommandBarControl myToolsControl = menuBarCommandBar.Controls.Add(MsoControlType.msoControlPopup, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                myToolsControl.Caption = "李仙伟";

                CommandBarPopup toolsPopup = (CommandBarPopup)myToolsControl;

                //如果希望添加多个由您的外接程序处理的命令，可以重复此 try/catch 块，
                //  只需确保更新 QueryStatus/Exec 方法，使其包含新的命令名。
                try
                {
                    //将一个命令添加到 Commands 集合:
                    Command command = this.GetExistCommand(commands, "PlatformSetting");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "PlatformSetting", "目标平台设置(&P)", "批量修改目标平台", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    //将对应于该命令的控件添加到“李仙伟”菜单:
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 1);
                    }
                }
                catch (System.ArgumentException)
                {
                    //如果出现此异常，原因很可能是由于具有该名称的命令
                    //  已存在。如果确实如此，则无需重新创建此命令，并且
                    //  可以放心忽略此异常。
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "OutPathSetting");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "OutPathSetting", "输出路径设置(&O)", "批量修改输出路径设置", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 2);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "BuildEventSetting");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "BuildEventSetting", "生成事件设置(&E)", "批量修改生成事件", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 3);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "NetFrameweorkSetting");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "NetFrameweorkSetting", ".NET版本设置(&N)", "批量修改.NET版本", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 4);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "CollapseAll");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "CollapseAll", "折叠所有项目(&C)", "折叠所有项目", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 5);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "ExpandAll");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "ExpandAll", "展开所有项目(&X)", "展开所有项目", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 6);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "MultiLoadProjects");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "MultiLoadProjects", "批量加载项目", "批量加载项目", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 7);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "MultiCreateProjects");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "MultiCreateProjects", "批量创建项目", "批量创建项目", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 8);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "DllRefConfig");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "DllRefConfig", "修改项目dll引用", "修改项目dll引用", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 9);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "DllRefFileCopy");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "DllRefFileCopy", "拷贝dll的引用(依赖项)", "拷贝dll的引用(依赖项)", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 10);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "Dll2Lib");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "Dll2Lib", "更新dll到Lib", "更新dll到Lib", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 11);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "SQLCreator");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "SQLCreator", "SQL语句生成器", "SQL语句生成器", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 12);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "GuidCreator");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "GuidCreator", "Guid生成器", "Guid生成器", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 13);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "CheckRepeatDll");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "CheckRepeatDll", "检查Lib库重复的dll", "检查Lib库重复的dll", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 14);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "Selection2Upper");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "Selection2Upper", "Selection2Upper", "Selection2Upper", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 15);
                    }
                }
                catch (System.ArgumentException)
                {
                }
                try
                {
                    Command command = this.GetExistCommand(commands, "AboutMe");
                    if (command == null)
                    {
                        command = commands.AddNamedCommand2(_addIn, "AboutMe", "关于(&A)", "关于", false, 1, ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);
                    }
                    if ((command != null) && (toolsPopup != null))
                    {
                        command.AddControl(toolsPopup.CommandBar, 16);
                    }
                }
                catch (System.ArgumentException)
                {
                }
            }

            //清理临时文件
            DllRefReflectUtility.ClearTempFiles();
		}

		/// <summary>实现 IDTExtensibility2 接口的 OnDisconnection 方法。接收正在卸载外接程序的通知。</summary>
		/// <param term='disconnectMode'>描述外接程序的卸载方式。</param>
		/// <param term='custom'>特定于宿主应用程序的参数数组。</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
		{
            if (_app == null)
            {
                return;
            }
            CommandBar menuBarCommandBar = ((CommandBars)_app.CommandBars)["MenuBar"];
            CommandBarControl cmdCtr = this.GetExistCommandBarControl(menuBarCommandBar, "李仙伟");
            if (cmdCtr != null)
            {
                cmdCtr.Visible = false;
            }          
		}

		/// <summary>实现 IDTExtensibility2 接口的 OnAddInsUpdate 方法。当外接程序集合已发生更改时接收通知。</summary>
		/// <param term='custom'>特定于宿主应用程序的参数数组。</param>
		/// <seealso class='IDTExtensibility2' />		
		public void OnAddInsUpdate(ref Array custom)
        {           

		}

		/// <summary>实现 IDTExtensibility2 接口的 OnStartupComplete 方法。接收宿主应用程序已完成加载的通知。</summary>
		/// <param term='custom'>特定于宿主应用程序的参数数组。</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref Array custom)
        {          

		}

		/// <summary>实现 IDTExtensibility2 接口的 OnBeginShutdown 方法。接收正在卸载宿主应用程序的通知。</summary>
		/// <param term='custom'>特定于宿主应用程序的参数数组。</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref Array custom)
		{
		}

        /// <summary>实现 IDTCommandTarget 接口的 QueryStatus 方法。此方法在更新该命令的可用性时调用</summary>
        /// <param term='commandName'>要确定其状态的命令的名称。</param>
        /// <param term='neededText'>该命令所需的文本。</param>
        /// <param term='status'>该命令在用户界面中的状态。</param>
        /// <param term='commandText'>neededText 参数所要求的文本。</param>
        /// <seealso class='Exec' />
        public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            if (neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
            {
                if (commandName == "Leation.VSAddin.Connect.PlatformSetting")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.OutPathSetting")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.BuildEventSetting")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.NetFrameweorkSetting")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.CollapseAll")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.ExpandAll")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.MultiLoadProjects")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.MultiCreateProjects")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.DllRefConfig")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.DllRefFileCopy")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.Dll2Lib")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.SQLCreator")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.GuidCreator")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.CheckRepeatDll")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.Selection2Upper")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.AboutMe")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
            }
        }

        /// <summary>实现 IDTCommandTarget 接口的 Exec 方法。此方法在调用该命令时调用。</summary>
        /// <param term='commandName'>要执行的命令的名称。</param>
        /// <param term='executeOption'>描述该命令应如何运行。</param>
        /// <param term='varIn'>从调用方传递到命令处理程序的参数。</param>
        /// <param term='varOut'>从命令处理程序传递到调用方的参数。</param>
        /// <param term='handled'>通知调用方此命令是否已被处理。</param>
        /// <seealso class='Exec' />
        public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            handled = false;
            if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
            {
                if (commandName == "Leation.VSAddin.Connect.PlatformSetting")
                {
                    frmPlatformSetting frm = new frmPlatformSetting(_app);
                    frm.ShowDialog();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.OutPathSetting")
                {
                    frmOutPathSetting frm = new frmOutPathSetting(_app);
                    frm.ShowDialog();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.BuildEventSetting")
                {
                    frmBuildEventSetting frm = new frmBuildEventSetting(_app);
                    frm.ShowDialog();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.NetFrameweorkSetting")
                {
                    frmNetFrameworkSetting frm = new frmNetFrameworkSetting(_app);
                    frm.ShowDialog();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.CollapseAll")
                {
                    SolutionExployerUtility utility = new SolutionExployerUtility(_app);
                    utility.CollapseAll();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.ExpandAll")
                {
                    SolutionExployerUtility utility = new SolutionExployerUtility(_app);
                    utility.ExpandAll();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.MultiLoadProjects")
                {
                    frmMultiLoadProjects frm = new frmMultiLoadProjects(_app);
                    frm.ShowDialog();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.MultiCreateProjects")
                {
                    frmMultiCreateProjects frm = new frmMultiCreateProjects(_app);
                    frm.ShowDialog();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.DllRefConfig")
                {
                    frmDllRefSetting frm = new  frmDllRefSetting(_app);
                    frm.ShowDialog();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.DllRefFileCopy")
                {
                    frmDllRefFileCopy frm = new frmDllRefFileCopy(_app);
                    frm.ShowDialog();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.Dll2Lib")
                {
                    frmDll2Lib frm = new frmDll2Lib(_app);
                    frm.ShowDialog();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.SQLCreator")
                {
                    Form frm = new Form();
                    frm.FormBorderStyle = FormBorderStyle.Sizable;
                    frm.ShowIcon = false;
                    frm.Width = 800;
                    frm.Height = 520;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "SQL语句生成器";
                    SQLCreatorUI ctr = new SQLCreatorUI();
                    ctr.Dock = DockStyle.Fill;
                    frm.Controls.Add(ctr);
                    frm.ShowDialog();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.GuidCreator")
                {
                    Form frm = new Form();
                    frm.FormBorderStyle = FormBorderStyle.Sizable;
                    frm.ShowIcon = false;
                    frm.Width = 800;
                    frm.Height = 520;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Text = "Guid生成器";
                    GuidCreatorUI ctr = new GuidCreatorUI();
                    ctr.Dock = DockStyle.Fill;
                    frm.Controls.Add(ctr);
                    frm.ShowDialog();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.CheckRepeatDll")
                {
                    frmCheckRepeatDll frm = new frmCheckRepeatDll(_app);
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.Selection2Upper")
                {
                    frmSelection2Upper frm = new frmSelection2Upper();

                    frm.BtnSelection2Upper.Click += delegate(object sender, EventArgs e)
                    {
                        try
                        {
                            TextSelection txtSelection = _app.ActiveDocument.Selection as TextSelection;
                            if (txtSelection != null)
                            {
                                txtSelection.Text = txtSelection.Text.ToUpper();
                            }
                        }
                        catch (Exception ex)
                        {
                            MsgBox.ShowTip(ex.Message);
                        }
                    };
                    frm.BtnSelection2Lower.Click += delegate(object sender, EventArgs e)
                    {
                        try
                        {
                            TextSelection txtSelection = _app.ActiveDocument.Selection as TextSelection;
                            if (txtSelection != null)
                            {
                                txtSelection.Text = txtSelection.Text.ToLower();
                            }
                        }
                        catch (Exception ex)
                        {
                            MsgBox.ShowTip(ex.Message);
                        }
                    };
                    frm.Show();

                    handled = true;
                    return;
                }
                if (commandName == "Leation.VSAddin.Connect.AboutMe")
                {
                    MsgBox.ShowTip("李仙伟\r\nQQ:744757242\r\nCopyright(c)2013 Leation");
                    
                    handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// 查找已经存在的命令
        /// </summary>
        /// <param name="commands">Commands2对象</param>
        /// <param name="name">命令的Name</param>
        /// <returns></returns>
        private Command GetExistCommand(Commands2 commands,string name)
        {
            foreach (Command cmd in commands)
            {
                if (cmd.Name == "Leation.VSAddin.Connect." + name)
                {
                    return cmd;
                }
            }
            return null;
        }

        /// <summary>
        /// 查找已经存在的菜单项
        /// </summary>
        /// <param name="cmdBar">菜单项CommandBar对象</param>
        /// <param name="caption">菜单项的标题</param>
        /// <returns></returns>
        private CommandBarControl GetExistCommandBarControl(CommandBar cmdBar, string caption)
        {
            string toolsMenuName;

            try
            {
                //若要将此命令移动到另一个菜单，则将“工具”一词更改为此菜单的英文版。
                //  此代码将获取区域性，将其追加到菜单名中，然后将此命令添加到该菜单中。
                //  您会在此文件中看到全部顶级菜单的列表
                //  CommandBar.resx.
                string resourceName;
                ResourceManager resourceManager = new ResourceManager("MyAddin2.CommandBar", Assembly.GetExecutingAssembly());
                CultureInfo cultureInfo = new CultureInfo(_app.LocaleID);

                if (cultureInfo.TwoLetterISOLanguageName == "zh")
                {
                    System.Globalization.CultureInfo parentCultureInfo = cultureInfo.Parent;
                    resourceName = String.Concat(parentCultureInfo.Name, caption);
                }
                else
                {
                    resourceName = String.Concat(cultureInfo.TwoLetterISOLanguageName, caption);
                }
                toolsMenuName = resourceManager.GetString(resourceName);
            }
            catch
            {
                //我们试图查找“工具”一词的本地化版本，但未能找到。
                //  默认值为 en-US 单词，该值可能适用于当前区域性。
                toolsMenuName = "李仙伟";
            }
            foreach (CommandBarControl cmdCtr in cmdBar.Controls)
            {
                if (cmdCtr.Caption == caption)
                {
                    return cmdCtr;
                }
            }
            return null;
        }
    }
}