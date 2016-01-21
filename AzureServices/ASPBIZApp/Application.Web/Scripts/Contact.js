
var DummyProfile = [
    {
        "ProfileId": 1,
        "FirstName": "Anand",
        "LastName": "Pandey",
        "Email": "anand@anandpandey.com"
    },
    {
        "ProfileId": 2,
        "FirstName": "John",
        "LastName": "Cena",
        "Email": "john@cena.com"
    }
];

var ProfilesViewModel = function () {
    var self = this;
    var refresh = function () {
        self.Profiles(DummyProfile);
    };

    //public data properties;
    self.Profiles = ko.observableArray([]);
    refresh();


    self.createProfile = function () {
        window.location.href = '/Contact/CreateEdit/0';
    };

    self.editProfile = function (profile) {
        window.location.href = '/Contact/CreateEdit/' + profile.ProfileId;
    };

    self.removeProfile = function (profile) {
        if (confirm("Are you sure you want to delete this profile?")) {
            self.Profiles.remove(profile);
        }
    };

};



//Activate Knockout
ko.applyBindings(new ProfilesViewModel());