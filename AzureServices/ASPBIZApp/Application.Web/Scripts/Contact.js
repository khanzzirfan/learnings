
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
]

var ProfilesViewModel = function () {
    var self = this;
    var refresh = function () {
        self.Profiles(DummyProfile);
    };

    //public data properties;
    self.Profiles = ko.observableArray([]);
    refresh();
};

self.createProfile = function()
{
    alert("Create new profile.");
};

self.editProfile = function (profile) {
    alert("Edit this profile with profile id as: " + profile.ProfileId);
};

self.removeProfile = function (profile)
{
    if (confirm("Are you sure you want to delete this profile?")) {
        self.Profiles.remove(profile);
    }
};
ko.applyBindings(new ProfilesViewModel());