
var person = function (id, name, email) {
    var self = this;
    self.id = ko.observable(id);
    self.name = ko.observable(name);
    self.email = ko.observable(email);
}

var personViewModel = function () {
    var self = this;
    self.name = ko.observable().extend({
        required: true
    });
    self.email = ko.observable().extend({
        required: true,
        email: true
    });
    // Editable data
    self.persons = ko.observableArray();

    // Operations
    self.addPerson = function () {
        if (self.name.isValid() && self.email.isValid()) {
            var id = self.persons().length + 1;
            self.persons.push(new person(id,self.name(), self.email()));
            self.name('');
            self.email('');
        }
    }



    //RemoveItem
    self.removePerson = function (person) {
        self.persons.remove(person);
    }

    name: ko.observable().extend({
        required: true
    });
    email: ko.observable().extend({
        required: true,
        email: true
    });

    self.closePopover = function (person) {
        $('#popover' + person.id + "_click").popover("hide");
    };

}

ko.applyBindings(new personViewModel());

ko.bindingHandlers.popUp = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var attribute = ko.utils.unwrapObservable(valueAccessor());
        var templateContent = attribute.content;
        var popOverTemplate = "<div class='popOverClass' id='" + attribute.id + "-popover'>" + $(templateContent).html() + "</div>";
        alert(element);
        $('#nno').popover({
            placement: 'right',
            content: popOverTemplate,
            html: true,
            trigger: 'manual'
        });
        $(element).attr('id', "popover" + attribute.id + "_click");
        $(element).click(function () {
            $(".popOverClass").popover("hide");
            $(this).popover('toggle');
            var thePopover = document.getElementById(attribute.id + "-popover");
            childBindingContext = bindingContext.createChildContext(viewModel);
            ko.applyBindingsToDescendants(childBindingContext, thePopover);
        })
    }
}




