ko.bindingHandlers.SetCSSandPopover = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var cssClass = ko.utils.unwrapObservable(valueAccessor);
        var obs = ko.utils.unwrapObservable(allBindingsAccessor()).value;

        if (true) {
            $(element).addClass(cssClass);
            $(element).popover({
                trigger: "hover",
                html: true,
                content: function () {
                    return $(element).next()[0].title;
                },
                container: "body",
                placement: "top",
                template: '<div class="popover"><div class="arrow"></div><div class="popover-inner"><div class="popover-content"><p></p></div></div></div>'
            });
        }
        else {
            $(element).removeClass(cssClass);
            $(element).popover("destroy");
        }
    }
};
ko.bindingHandlers.SetParentPopover = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var cssClass = ko.utils.unwrapObservable(valueAccessor);
        var obs = ko.utils.unwrapObservable(allBindingsAccessor()).value;

        var decorateElement = obs.isModified() && !obs.isValid();
        if (decorateElement) {
            $(element).parent().addClass(cssClass);
            $(element).parent().popover({
                trigger: "hover",
                html: true,
                content: function () {
                    return $(element).next()[0].title;
                },
                container: "body",
                placement: "top",
                template: '<div class="popover"><div class="arrow"></div><div class="popover-inner"><div class="popover-content"><p></p></div></div></div>'
            });
        }
        else {
            $(element).parent().removeClass(cssClass);
            $(element).parent().popover("destroy");
        }
    }
};