using System;
#if NETCF || WINDOWS
using System.Windows.Forms;
#elif SL || WPF
using System.Windows;
#endif

namespace Upp.Shared.Utilities
{
	public sealed class Messages
	{
		#region Methods.Error
#if NETCF
		public static void ShowError(string error)
		{
			MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
		}
#elif SL || WPF
		public static void ShowError(string error)
		{
			MessageBox.Show(error, "Error", MessageBoxButton.OK);
		}
#elif WINDOWS
		public static void ShowError(string error)
		{
			MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
#endif
		public static void ShowError(string format, params object[] args)
		{
			Messages.ShowError(String.Format(format, args));
		}
		#endregion

		#region Methods.Message
#if NETCF
		public static void ShowMessage(string message)
		{
			MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
		}
#elif SL || WPF
		public static void ShowMessage(string message)
		{
			MessageBox.Show(message, "Message", MessageBoxButton.OK);
		}
#elif WINDOWS
		public static void ShowMessage(string message)
		{
			MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
#endif
		public static void ShowMessage(string format, params object[] args)
		{
			Messages.ShowMessage(String.Format(format, args));
		}
		#endregion

		#region Methods.Question
#if NETCF
		public static DialogResult ShowQuestion(string question)
		{
			return MessageBox.Show(question, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
		}

		public static DialogResult ShowQuestion(string format, params object[] args)
		{
			return Messages.ShowQuestion(String.Format(format, args));
		}
#elif SL || WPF
		public static MessageBoxResult ShowQuestion(string question)
		{
			return MessageBox.Show(question, "Question", MessageBoxButton.OKCancel);
		}

		public static MessageBoxResult ShowQuestion(string format, params object[] args)
		{
			return Messages.ShowQuestion(String.Format(format, args));
		}
#elif WINDOWS
		public static DialogResult ShowQuestion(string question)
		{
			return MessageBox.Show(question, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		public static DialogResult ShowQuestion(string format, params object[] args)
		{
			return Messages.ShowQuestion(String.Format(format, args));
		}
#endif
		#endregion

		#region Methods.Warning
#if NETCF
		public static void ShowWarning(string warning)
		{
			MessageBox.Show(warning, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
		}
#elif SL || WPF
		public static void ShowWarning(string warning)
		{
			MessageBox.Show(warning, "Warning", MessageBoxButton.OK);
		}
#elif WINDOWS
		public static void ShowWarning(string warning)
		{
			MessageBox.Show(warning, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
#endif
		public static void ShowWarning(string format, params object[] args)
		{
			Messages.ShowWarning(String.Format(format, args));
		}
		#endregion
	}
}
