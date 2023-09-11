using PlatformView = SwipeActivationIssue.Custom.CustomMauiSwipeView;
using Microsoft.Maui.Handlers;
using SwipeActivationIssue.Custom;

namespace SwipeActivationIssue.Handlers
{
    public partial class CustomSwipeViewHandler : ViewHandler<ISwipeView, CustomMauiSwipeView>, ICustomSwipeViewHandler
    {
        public static IPropertyMapper<ISwipeView, ICustomSwipeViewHandler> Mapper = new PropertyMapper<ISwipeView, ICustomSwipeViewHandler>(ViewHandler.ViewMapper)
        {
            [nameof(IContentView.Content)] = MapContent,
            [nameof(ISwipeView.SwipeTransitionMode)] = MapSwipeTransitionMode,
            [nameof(ISwipeView.LeftItems)] = MapLeftItems,
            [nameof(ISwipeView.TopItems)] = MapTopItems,
            [nameof(ISwipeView.RightItems)] = MapRightItems,
            [nameof(ISwipeView.BottomItems)] = MapBottomItems,
#if ANDROID || IOS || TIZEN
			[nameof(IView.IsEnabled)] = MapIsEnabled,
#endif
#if ANDROID
			[nameof(IView.Background)] = MapBackground,
#endif
        };

        public static CommandMapper<ISwipeView, ICustomSwipeViewHandler> CommandMapper = new(ViewCommandMapper)
        {
            [nameof(ISwipeView.RequestOpen)] = MapRequestOpen,
            [nameof(ISwipeView.RequestClose)] = MapRequestClose,
        };

        public CustomSwipeViewHandler() : base(Mapper, CommandMapper)
        {

        }

        public CustomSwipeViewHandler(IPropertyMapper? mapper)
            : base(mapper ?? Mapper, CommandMapper)
        {
        }

        public CustomSwipeViewHandler(IPropertyMapper? mapper, CommandMapper? commandMapper)
            : base(mapper ?? Mapper, commandMapper ?? CommandMapper)
        {
        }

        ISwipeView ICustomSwipeViewHandler.VirtualView => VirtualView;

        PlatformView ICustomSwipeViewHandler.PlatformView => PlatformView;
    }
}
