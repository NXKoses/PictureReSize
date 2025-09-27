using Microsoft.WindowsAPICodePack.Taskbar;

namespace PictureReSize.component
{
    class Function
    {
        public static void Taskbar(int cnt, int max)
        {
            if (max <= cnt)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                return;
            }
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            TaskbarManager.Instance.SetProgressValue(cnt, max);
        }
    }
}
