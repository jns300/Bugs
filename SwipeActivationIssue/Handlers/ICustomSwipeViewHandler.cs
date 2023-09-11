using PlatformView = SwipeActivationIssue.Custom.CustomMauiSwipeView;


namespace SwipeActivationIssue.Handlers
{
    public partial interface ICustomSwipeViewHandler : IViewHandler, IElementHandler
    {
        new ISwipeView VirtualView { get; }
        new PlatformView PlatformView { get; }
    }
}
