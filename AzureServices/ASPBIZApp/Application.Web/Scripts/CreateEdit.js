var url = window.location.pathname;
var profileId = url.substring(url.lastIndexOf('/') + 1);
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



var AddressTypeData = [
{
    "AddressTypeId": 1,
    "Name": "Shipping Address"
},
    {
        "AddressTypeId": 2,
        "Name": "Billing Address"
    }
];

var PhoneTypeData = [
    {
        "PhoneTypeId": 1,
        "Name":"Work Phone"
    },
    {
        "PhoneTypeId": 2,
        "Name": "Personal Phone"
    }
];

var PhoneDTO = [
    {
        "PhoneId": 1,
        "PhoneTypeId": 1,
        "ProfileId": 1,
        "Number": "111-222-333",

    },
    {
        "PhoneId": 2,
        "PhoneTypeId": 2,
        "ProfileId": 1,
        "Number": "444-555-666",
    }
];

var AddressDTO = [
    {
        "AddressId": 1,
        "AddressTypeId": 1,
        "ProfileId": 1,
        "AddressLine1": "1000 Richmond Avenue",
        "AddressLine2": "APT #199",
        "Country": "USA",
        "State": "Texas",
        "City": "Houston",
        "ZipCode": "70000"
    },
    {
        "AddressId": 2,
        "AddressTypeId": 2,
        "ProfileId": 1,
        "AddressLine1": "1000 Highway 5",
        "AddressLine2": "Suit #200",
        "Country": "USA",
        "State": "Texas",
        "City": "Houston",
        "ZipCode": "70000"
    }
];

var Profile = function (profile) {
    var self = this;
    self.ProfileId = ko.observable(profile ? profile.ProfileId : 0).extend({required:true});
    self.FirstName = ko.observable(profile ? profile.FirstName : '').extend({required:true, maxLength:50});
    self.LastName = ko.observable(profile ? profile.LastName : '').extend({required:true, maxLength:50});
    self.Email = ko.observable(profile ? profile.Email : '').extend({required:true,maxLength:50, email:true});
    self.PhoneDTO = ko.observableArray(profile ? profile.PhoneDTO : []);
    self.AddressDTO = ko.observableArray(profile ? profile.AddressDTO : []);


};

var PhoneLine = function(phone) {
    var self = this;
    self.PhoneId = ko.observable(phone ? phone.PhoneId : 0);
    self.PhoneTypeId = ko.observable(phone ? phone.PhoneTypeId : 0).extend({required:true});
    self.Number = ko.observable(phone ? phone.Number : '').extend({required:true, maxLength:20, phoneUS:true});
};


var AddressLine = function(address) {
    var self = this;
    self.AddressId = ko.observable(address ? address.AddressId : 0);
    self.AddressTypeId = ko.observable(address ? address.AddressTypeId : 0);
    self.AddressLine1 = ko.observable(address ? address.AddressLine1 : '');
    self.AddressLine2 = ko.observable(address ? address.AddressLine2 : '');
    self.City = ko.observable(address ? address.City : '');
    self.State = ko.observable(address ? address.State : '');
    self.Country = ko.observable(address ? address.Country : '');
    self.ZipCode = ko.observable(address ? address.ZipCode : '');
};
var ProfileCollection = function() {
    var self = this;

    //if ProfileId is 0 means create new profile
    if (profileId == 0) {
        self.profile = ko.observable(new Profile());
        self.phoneNumbers = ko.observableArray([new PhoneLine()]);
        self.addresses = ko.observableArray([new AddressLine()]);
    }
    else
    {
        var currentProfile = $.grep(DummyProfile, function (e) {
            return e.ProfileId == profileId;
        });

        self.profile = ko.observable(new Profile(currentProfile[0]));

        var currentProfilePhone = $.grep(PhoneDTO, function(e) {
            return e.ProfileId == profileId;
        });

        self.phoneNumbers = ko.observableArray(ko.utils.arrayMap(currentProfilePhone, function(phone) {
            return phone;
        }));

        var currentProfileAddress = $.grep(AddressDTO, function(e) {
            return e.ProfileId == profileId;
        });

        self.addresses = ko.observableArray(ko.utils.arrayMap(currentProfileAddress, function(address) {
            return address;
        }));
    }

    self.addPhone = function() {
        self.phoneNumbers.push(new PhoneLine());
    };

    self.removePhone = function(phone) {
        self.phoneNumbers.remove(phone);
    };

    self.addAddress = function() {
        self.addresses.push(new AddressLine());
    };

    self.removeAddress = function (address) {
        self.addresses.remove(address);
    }

    self.backToProfileList = function() {
        window.location.href = '/contact';
    };

    self.saveProfile = function () {
        self.profile().AddressDTO = self.addresses;
        self.profile().PhoneDTO = self.phoneNumbers;
        alert("Date to save is : " + JSON.stringify(ko.toJS(self.profile())));
    };


};

//Activate the Knockou JS bindings using ko.applyBindings();
ko.applyBindings(new ProfileCollection());