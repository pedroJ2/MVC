var id = 1;
var person = function (id, name, email) {
    var self = this;
    self.id = id;
    self.name = ko.observable(name).extend({
        minLength: 4,
        required: {
            message: "Enter a name",
            params: true
        }
    });
    self.email = ko.observable(email).extend({
        required: {
            message: "Enter a email",
            params: true
        },
        email: {
            message: "Enter a validate email address.",
            params: true
        }
    });
}

var personViewModel = function () {
    var self = this;
    self.name = ko.observable().extend({
        minLength: 4,
        required: {
            message: "Enter a name",
            params: true
        }
    });
    self.email = ko.observable().extend({
        required:{
            message: "Enter a email",
            params: true
        },
        email: {
            message: "Enter a validate email address.",
            params: true
        }
    });
    // Editable data
    self.persons = ko.observableArray();
    // Operations
    self.addPerson = function () {
        if (self.validate()) {
            self.persons.push(new person(id, self.name(), self.email()));
            self.name('');
            self.email('');
            id++;
        } else {
            $("#alertPersona").show();
            $("#alertPersona").fadeTo(2000, 500).slideUp(500, function () {
                $("#alertPersona").hide();
            });
        }
    }
    //RemoveItem
    self.removePerson = function (person) {
        self.persons.remove(person);
    }
    self.filter = ko.observable("");
    self.filteredItems = ko.computed(function () {
        var filter = self.filter().toLowerCase();
        if (!filter) {
            return self.persons();
        } else {
            return ko.utils.arrayFilter(self.persons(), function (item) {
                return ko.utils.stringStartsWith(item.name().toLowerCase(), filter);
            });
        }
    });
    self.validate = ko.computed(function () {
        per = new person(id, self.name(), self.email());
        var name = ko.utils.arrayFirst(self.persons(), function (item) {
            return per.name() === item.name();
        });
        var email = ko.utils.arrayFirst(self.persons(), function (item) {
            return per.email() === item.email();
        });
        if (!name && !email && self.email.isValid() && self.name.isValid()) {
            return true;
        } else {
            return false;
        }
    });
    self.validatePopClose = function (person) {
        var name = ko.utils.arrayFirst(self.persons(), function (item) {
            return person.name() === item.name() && person.id !== item.id;
        });
        var email = ko.utils.arrayFirst(self.persons(), function (item) {
            return person.email() === item.email() && person.id !== item.id;
        });
        if (!name && !email) {
            $('#popover' + person.id + "_click").popover("hide");
        } else {
            $("#alertPersona-pop").show();
            $("#alertPersona-pop").fadeTo(2000, 500).slideUp(500, function () {
                $("#alertPersona-pop").hide();
            });
        }
    };
}

ko.bindingHandlers.popUp = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var attribute = ko.utils.unwrapObservable(valueAccessor());
        var templateContent = attribute.content;
        var popOverTemplate = "<div class='popOverClass' id='" + attribute.id + "-popover'>" + $(templateContent).html() + "</div>";
        $(element).popover({
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
            $("#alertPersona-pop").hide();
            ko.applyBindingsToDescendants(childBindingContext, thePopover);
        })
    }
}

ko.applyBindings(new personViewModel());
