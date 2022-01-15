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
            var defaultStyle = "b-mx-auto sm:b-w-11/12 md:b-w-9/12";
            switch (modalSize)
            {
                case ModalSize.Content:
                    return $"b-mx-auto";
                case ModalSize.Small:
                    return $"{defaultStyle} lg:b-w-4/12";
                case ModalSize.Medium:
                    return $"{defaultStyle} lg:b-w-1/2";
                case ModalSize.Large:
                    return $"{defaultStyle}";
                case ModalSize.Full:
                    return "b-w-full";
                default:
                    return string.Empty;
            }
        }
    }
}
