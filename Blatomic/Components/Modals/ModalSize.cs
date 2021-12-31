namespace Blatomic.Components.Modals
{
    public enum ModalSize
    {
        Content,
        Small,
        Medium,
        Large,
        Full
    }

    public static class ModalSizeExtensions
    {
        public static string GetStyle(this ModalSize modalSize)
        {
            var defaultStyle = "mx-auto sm:w-11/12 md:w-9/12";
            switch (modalSize)
            {
                case ModalSize.Content:
                    return $"mx-auto";
                case ModalSize.Small:
                    return $"{defaultStyle} lg:w-4/12";
                case ModalSize.Medium:
                    return $"{defaultStyle} lg:w-1/2";
                case ModalSize.Large:
                    return $"{defaultStyle}";
                case ModalSize.Full:
                    return "w-full";
                default:
                    return string.Empty;
            }
        }
    }
}
