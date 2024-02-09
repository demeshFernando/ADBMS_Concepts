create database dk_pawn_center

use dk_pawn_center

create table customers (
	id varchar(100),
	firstName varchar(100), 
	lastName varchar(100), 
	otherNames varchar(100), 
	line1 varchar(100), 
	line2 varchar(100), 
	line3 varchar(100), 
	city varchar(100), 
	secondaryContactMethod varchar(100), 
	registeredBy varchar(100)
)

create table customer_contact(
	id varchar(100), 
	phoneNumber varchar(100), 
	email varchar(100)
)

create table pawned_item(
	id varchar(100), 
	ownerId varchar(100), 
	itemName varchar(100), 
	itemDescription varchar(100),
	estimatedCarrotValue varchar(100), 
	descriptionApprovedAmount varchar(100), 
	yearlyInterest varchar(100),
	paymentMethod varchar(100), 
	takenAmount varchar(100), 
	calculatedInterestFor varchar(100), 
	approvedStaff varchar(100), 
	ownerVerification varchar(100), 
	estimatedValue varchar(100), 
	approvedAmount varchar(100), 
	storedLockerId varchar(100)
)

create table staff_members(
	id varchar(100), 
	firstName varchar(100), 
	lastName varchar(100), 
	otherNames varchar(100), 
	line1 varchar(100), 
	line2 varchar(100), 
	line3 varchar(100), 
	city varchar(100), 
	availableLeaves varchar(100), 
	username varchar(100), 
	userPassword varchar(100), 
	currentEmployementStatus varchar(100), 
	jobDescriptionLink varchar(100), 
	cvLink varchar(100), 
	positionId varchar(100), 
	registeredDay varchar(100), 
	registeredMonth  varchar(100), 
	registeredYear varchar(100), 
	applicableLeaves varchar(100)
)

create table staff_position(
	id varchar(100), 
	position varchar(100), 
	basicSalary varchar(100)
)

create table staff_contact_number(
	id varchar(100), 
	phoneNumber varchar(100), 
	email varchar(100), 
	bankAccountNumber varchar(100)
)

create table agrement_links(
	id varchar(100), 
	agrementLink varchar(100)
)

create table payment_log(
	id varchar(100), 
	usingTable varchar(100), 
	logDescription varchar(100),
	registeredDay varchar(100), 
	registeredMonth varchar(100), 
	registeredYear varchar(100), 
	registeredHour varchar(100), 
	registeredMinute varchar(100),
	transferedAmount varchar(100), 
	accountNumber varchar(100), 
	bank varchar(100), 
	actionperformedBy varchar(100), 
	capital varchar(100), 
	paymentMethod varchar(100), 
	transactionConfirmation varchar(100)
)

create table general_log(
	id varchar(100), 
	usingTable varchar(100), 
	logDescription varchar(100), 
	registeredDay varchar(100), 
	registeredMonth varchar(100), 
	registeredYear varchar(100), 
	registeredHour varchar(100), 
	registeredMinute varchar(100), 
	actionPerformedBy varchar(100)
)

create table bills(
	id varchar(100), 
	customerId varchar(100), 
	detailsFilledBy varchar(100), 
	isCustomerAware varchar(100), 
	billType varchar(100),
	isIncome varchar(100), 
	interest varchar(100), 
	total varchar(100), 
	registeredDay varchar(100), 
	registeredMonth varchar(100), 
	registeredYear varchar(100), 
	registeredHour varchar(100), 
	registeredMinute varchar(100),
)

create table locker_details(
	id varchar(100), 
	lockerName varchar(100), 
	lockerOwner varchar(100), 
	lockerDescription varchar(100),
	line1 varchar(100), 
	line2 varchar(100), 
	line3 varchar(100), 
	city varchar(100), 
	registeredDay varchar(100), 
	registeredMonth varchar(100), 
	registeredYear varchar(100),
)

select * from staff_members
select * from customers
select * from customer_contact
select * from pawned_item

delete from staff_members
delete from customers
delete from customer_contact
delete from pawned_item