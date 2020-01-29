"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var account = /** @class */ (function () {
    function account() {
    }
    return account;
}());
exports.account = account;
var address1_addresstypecodeEnum;
(function (address1_addresstypecodeEnum) {
    address1_addresstypecodeEnum[address1_addresstypecodeEnum["BillTo"] = 1] = "BillTo";
    address1_addresstypecodeEnum[address1_addresstypecodeEnum["ShipTo"] = 2] = "ShipTo";
    address1_addresstypecodeEnum[address1_addresstypecodeEnum["Primary"] = 3] = "Primary";
    address1_addresstypecodeEnum[address1_addresstypecodeEnum["Other"] = 4] = "Other";
})(address1_addresstypecodeEnum = exports.address1_addresstypecodeEnum || (exports.address1_addresstypecodeEnum = {}));
var address1_shippingmethodcodeEnum;
(function (address1_shippingmethodcodeEnum) {
    address1_shippingmethodcodeEnum[address1_shippingmethodcodeEnum["Airborne"] = 1] = "Airborne";
    address1_shippingmethodcodeEnum[address1_shippingmethodcodeEnum["DHL"] = 2] = "DHL";
    address1_shippingmethodcodeEnum[address1_shippingmethodcodeEnum["FedEx"] = 3] = "FedEx";
    address1_shippingmethodcodeEnum[address1_shippingmethodcodeEnum["UPS"] = 4] = "UPS";
    address1_shippingmethodcodeEnum[address1_shippingmethodcodeEnum["PostalMail"] = 5] = "PostalMail";
    address1_shippingmethodcodeEnum[address1_shippingmethodcodeEnum["FullLoad"] = 6] = "FullLoad";
    address1_shippingmethodcodeEnum[address1_shippingmethodcodeEnum["WillCall"] = 7] = "WillCall";
})(address1_shippingmethodcodeEnum = exports.address1_shippingmethodcodeEnum || (exports.address1_shippingmethodcodeEnum = {}));
var statuscodeEnum;
(function (statuscodeEnum) {
})(statuscodeEnum = exports.statuscodeEnum || (exports.statuscodeEnum = {}));
var address1_freighttermscodeEnum;
(function (address1_freighttermscodeEnum) {
    address1_freighttermscodeEnum[address1_freighttermscodeEnum["FOB"] = 1] = "FOB";
    address1_freighttermscodeEnum[address1_freighttermscodeEnum["NoCharge"] = 2] = "NoCharge";
})(address1_freighttermscodeEnum = exports.address1_freighttermscodeEnum || (exports.address1_freighttermscodeEnum = {}));
var accountratingcodeEnum;
(function (accountratingcodeEnum) {
    accountratingcodeEnum[accountratingcodeEnum["DefaultValue"] = 1] = "DefaultValue";
})(accountratingcodeEnum = exports.accountratingcodeEnum || (exports.accountratingcodeEnum = {}));
var preferredappointmenttimecodeEnum;
(function (preferredappointmenttimecodeEnum) {
    preferredappointmenttimecodeEnum[preferredappointmenttimecodeEnum["Morning"] = 1] = "Morning";
    preferredappointmenttimecodeEnum[preferredappointmenttimecodeEnum["Afternoon"] = 2] = "Afternoon";
    preferredappointmenttimecodeEnum[preferredappointmenttimecodeEnum["Evening"] = 3] = "Evening";
})(preferredappointmenttimecodeEnum = exports.preferredappointmenttimecodeEnum || (exports.preferredappointmenttimecodeEnum = {}));
var accountclassificationcodeEnum;
(function (accountclassificationcodeEnum) {
    accountclassificationcodeEnum[accountclassificationcodeEnum["DefaultValue"] = 1] = "DefaultValue";
})(accountclassificationcodeEnum = exports.accountclassificationcodeEnum || (exports.accountclassificationcodeEnum = {}));
var customertypecodeEnum;
(function (customertypecodeEnum) {
    customertypecodeEnum[customertypecodeEnum["Competitor"] = 1] = "Competitor";
    customertypecodeEnum[customertypecodeEnum["Consultant"] = 2] = "Consultant";
    customertypecodeEnum[customertypecodeEnum["Customer"] = 3] = "Customer";
    customertypecodeEnum[customertypecodeEnum["Investor"] = 4] = "Investor";
    customertypecodeEnum[customertypecodeEnum["Partner"] = 5] = "Partner";
    customertypecodeEnum[customertypecodeEnum["Influencer"] = 6] = "Influencer";
    customertypecodeEnum[customertypecodeEnum["Press"] = 7] = "Press";
    customertypecodeEnum[customertypecodeEnum["Prospect"] = 8] = "Prospect";
    customertypecodeEnum[customertypecodeEnum["Reseller"] = 9] = "Reseller";
    customertypecodeEnum[customertypecodeEnum["Supplier"] = 10] = "Supplier";
    customertypecodeEnum[customertypecodeEnum["Vendor"] = 11] = "Vendor";
    customertypecodeEnum[customertypecodeEnum["Other"] = 12] = "Other";
})(customertypecodeEnum = exports.customertypecodeEnum || (exports.customertypecodeEnum = {}));
var preferredcontactmethodcodeEnum;
(function (preferredcontactmethodcodeEnum) {
    preferredcontactmethodcodeEnum[preferredcontactmethodcodeEnum["Any"] = 1] = "Any";
    preferredcontactmethodcodeEnum[preferredcontactmethodcodeEnum["Email"] = 2] = "Email";
    preferredcontactmethodcodeEnum[preferredcontactmethodcodeEnum["Phone"] = 3] = "Phone";
    preferredcontactmethodcodeEnum[preferredcontactmethodcodeEnum["Fax"] = 4] = "Fax";
    preferredcontactmethodcodeEnum[preferredcontactmethodcodeEnum["Mail"] = 5] = "Mail";
})(preferredcontactmethodcodeEnum = exports.preferredcontactmethodcodeEnum || (exports.preferredcontactmethodcodeEnum = {}));
var ownershipcodeEnum;
(function (ownershipcodeEnum) {
    ownershipcodeEnum[ownershipcodeEnum["Public"] = 1] = "Public";
    ownershipcodeEnum[ownershipcodeEnum["Private"] = 2] = "Private";
    ownershipcodeEnum[ownershipcodeEnum["Subsidiary"] = 3] = "Subsidiary";
    ownershipcodeEnum[ownershipcodeEnum["Other"] = 4] = "Other";
})(ownershipcodeEnum = exports.ownershipcodeEnum || (exports.ownershipcodeEnum = {}));
var address2_addresstypecodeEnum;
(function (address2_addresstypecodeEnum) {
    address2_addresstypecodeEnum[address2_addresstypecodeEnum["DefaultValue"] = 1] = "DefaultValue";
})(address2_addresstypecodeEnum = exports.address2_addresstypecodeEnum || (exports.address2_addresstypecodeEnum = {}));
var businesstypecodeEnum;
(function (businesstypecodeEnum) {
    businesstypecodeEnum[businesstypecodeEnum["DefaultValue"] = 1] = "DefaultValue";
})(businesstypecodeEnum = exports.businesstypecodeEnum || (exports.businesstypecodeEnum = {}));
var shippingmethodcodeEnum;
(function (shippingmethodcodeEnum) {
    shippingmethodcodeEnum[shippingmethodcodeEnum["DefaultValue"] = 1] = "DefaultValue";
})(shippingmethodcodeEnum = exports.shippingmethodcodeEnum || (exports.shippingmethodcodeEnum = {}));
var paymenttermscodeEnum;
(function (paymenttermscodeEnum) {
    paymenttermscodeEnum[paymenttermscodeEnum["Net30"] = 1] = "Net30";
    paymenttermscodeEnum[paymenttermscodeEnum["Net30210"] = 2] = "Net30210";
    paymenttermscodeEnum[paymenttermscodeEnum["Net45"] = 3] = "Net45";
    paymenttermscodeEnum[paymenttermscodeEnum["Net60"] = 4] = "Net60";
})(paymenttermscodeEnum = exports.paymenttermscodeEnum || (exports.paymenttermscodeEnum = {}));
var statecodeEnum;
(function (statecodeEnum) {
})(statecodeEnum = exports.statecodeEnum || (exports.statecodeEnum = {}));
var customersizecodeEnum;
(function (customersizecodeEnum) {
    customersizecodeEnum[customersizecodeEnum["DefaultValue"] = 1] = "DefaultValue";
})(customersizecodeEnum = exports.customersizecodeEnum || (exports.customersizecodeEnum = {}));
var accountcategorycodeEnum;
(function (accountcategorycodeEnum) {
    accountcategorycodeEnum[accountcategorycodeEnum["PreferredCustomer"] = 1] = "PreferredCustomer";
    accountcategorycodeEnum[accountcategorycodeEnum["Standard"] = 2] = "Standard";
})(accountcategorycodeEnum = exports.accountcategorycodeEnum || (exports.accountcategorycodeEnum = {}));
var industrycodeEnum;
(function (industrycodeEnum) {
    industrycodeEnum[industrycodeEnum["Accounting"] = 1] = "Accounting";
    industrycodeEnum[industrycodeEnum["AgricultureandNon_petrolNaturalResourceExtraction"] = 2] = "AgricultureandNon_petrolNaturalResourceExtraction";
    industrycodeEnum[industrycodeEnum["BroadcastingPrintingandPublishing"] = 3] = "BroadcastingPrintingandPublishing";
    industrycodeEnum[industrycodeEnum["Brokers"] = 4] = "Brokers";
    industrycodeEnum[industrycodeEnum["BuildingSupplyRetail"] = 5] = "BuildingSupplyRetail";
    industrycodeEnum[industrycodeEnum["BusinessServices"] = 6] = "BusinessServices";
    industrycodeEnum[industrycodeEnum["Consulting"] = 7] = "Consulting";
    industrycodeEnum[industrycodeEnum["ConsumerServices"] = 8] = "ConsumerServices";
    industrycodeEnum[industrycodeEnum["DesignDirectionandCreativeManagement"] = 9] = "DesignDirectionandCreativeManagement";
    industrycodeEnum[industrycodeEnum["DistributorsDispatchersandProcessors"] = 10] = "DistributorsDispatchersandProcessors";
    industrycodeEnum[industrycodeEnum["DoctorsOfficesandClinics"] = 11] = "DoctorsOfficesandClinics";
    industrycodeEnum[industrycodeEnum["DurableManufacturing"] = 12] = "DurableManufacturing";
    industrycodeEnum[industrycodeEnum["EatingandDrinkingPlaces"] = 13] = "EatingandDrinkingPlaces";
    industrycodeEnum[industrycodeEnum["EntertainmentRetail"] = 14] = "EntertainmentRetail";
    industrycodeEnum[industrycodeEnum["EquipmentRentalandLeasing"] = 15] = "EquipmentRentalandLeasing";
    industrycodeEnum[industrycodeEnum["Financial"] = 16] = "Financial";
    industrycodeEnum[industrycodeEnum["FoodandTobaccoProcessing"] = 17] = "FoodandTobaccoProcessing";
    industrycodeEnum[industrycodeEnum["InboundCapitalIntensiveProcessing"] = 18] = "InboundCapitalIntensiveProcessing";
    industrycodeEnum[industrycodeEnum["InboundRepairandServices"] = 19] = "InboundRepairandServices";
    industrycodeEnum[industrycodeEnum["Insurance"] = 20] = "Insurance";
    industrycodeEnum[industrycodeEnum["LegalServices"] = 21] = "LegalServices";
    industrycodeEnum[industrycodeEnum["Non_DurableMerchandiseRetail"] = 22] = "Non_DurableMerchandiseRetail";
    industrycodeEnum[industrycodeEnum["OutboundConsumerService"] = 23] = "OutboundConsumerService";
    industrycodeEnum[industrycodeEnum["PetrochemicalExtractionandDistribution"] = 24] = "PetrochemicalExtractionandDistribution";
    industrycodeEnum[industrycodeEnum["ServiceRetail"] = 25] = "ServiceRetail";
    industrycodeEnum[industrycodeEnum["SIGAffiliations"] = 26] = "SIGAffiliations";
    industrycodeEnum[industrycodeEnum["SocialServices"] = 27] = "SocialServices";
    industrycodeEnum[industrycodeEnum["SpecialOutboundTradeContractors"] = 28] = "SpecialOutboundTradeContractors";
    industrycodeEnum[industrycodeEnum["SpecialtyRealty"] = 29] = "SpecialtyRealty";
    industrycodeEnum[industrycodeEnum["Transportation"] = 30] = "Transportation";
    industrycodeEnum[industrycodeEnum["UtilityCreationandDistribution"] = 31] = "UtilityCreationandDistribution";
    industrycodeEnum[industrycodeEnum["VehicleRetail"] = 32] = "VehicleRetail";
    industrycodeEnum[industrycodeEnum["Wholesale"] = 33] = "Wholesale";
})(industrycodeEnum = exports.industrycodeEnum || (exports.industrycodeEnum = {}));
var preferredappointmentdaycodeEnum;
(function (preferredappointmentdaycodeEnum) {
    preferredappointmentdaycodeEnum[preferredappointmentdaycodeEnum["Sunday"] = 0] = "Sunday";
    preferredappointmentdaycodeEnum[preferredappointmentdaycodeEnum["Monday"] = 1] = "Monday";
    preferredappointmentdaycodeEnum[preferredappointmentdaycodeEnum["Tuesday"] = 2] = "Tuesday";
    preferredappointmentdaycodeEnum[preferredappointmentdaycodeEnum["Wednesday"] = 3] = "Wednesday";
    preferredappointmentdaycodeEnum[preferredappointmentdaycodeEnum["Thursday"] = 4] = "Thursday";
    preferredappointmentdaycodeEnum[preferredappointmentdaycodeEnum["Friday"] = 5] = "Friday";
    preferredappointmentdaycodeEnum[preferredappointmentdaycodeEnum["Saturday"] = 6] = "Saturday";
})(preferredappointmentdaycodeEnum = exports.preferredappointmentdaycodeEnum || (exports.preferredappointmentdaycodeEnum = {}));
var address2_shippingmethodcodeEnum;
(function (address2_shippingmethodcodeEnum) {
    address2_shippingmethodcodeEnum[address2_shippingmethodcodeEnum["DefaultValue"] = 1] = "DefaultValue";
})(address2_shippingmethodcodeEnum = exports.address2_shippingmethodcodeEnum || (exports.address2_shippingmethodcodeEnum = {}));
var address2_freighttermscodeEnum;
(function (address2_freighttermscodeEnum) {
    address2_freighttermscodeEnum[address2_freighttermscodeEnum["DefaultValue"] = 1] = "DefaultValue";
})(address2_freighttermscodeEnum = exports.address2_freighttermscodeEnum || (exports.address2_freighttermscodeEnum = {}));
var territorycodeEnum;
(function (territorycodeEnum) {
    territorycodeEnum[territorycodeEnum["DefaultValue"] = 1] = "DefaultValue";
})(territorycodeEnum = exports.territorycodeEnum || (exports.territorycodeEnum = {}));
//# sourceMappingURL=file1.js.map