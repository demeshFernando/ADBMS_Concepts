
create database DK_Pawn_Center;

use DK_Pawn_Center;

create table position(
	position_id varchar(100) primary key,
	position varchar(100),
	basic_salary varchar(100));


create table staff_member(
	stf_id varchar(100) primary key,
	first_name varchar(100),
	last_name varchar(100),
	other_names varchar(100),
	line1 varchar(100),
	line2 varchar(100),
	line3 varchar(100),
	city varchar(100),
	available_leaves varchar(100),
	use_name varchar(100),
	password varchar,
	current_Employment_Status varchar(100),
	job_description_link varchar(100),
	cv_link varchar(100),
	position_id varchar(100),
	foreign key(position_id) references position(position_id),
	registered_date varchar(100),
	registered_month varchar(100),
	registered_year varchar(100),
	applicable_leaves varchar(100));

	create trigger updating_staff_member ON staff_member
	after update
	as 
	begin
		INSERT INTO log VALUES(20, 'staffMember', 'updating values', '2020', '12', '12', '12', '12', 'staff-member')
	end


create table customers(
	cus_id varchar(100) primary key,
	first_name varchar(100),
	last_name varchar(100),
	other_name varchar(100),
	line1 varchar(100),
	line2 varchar(100),
	line3 varchar(100),
	city varchar(100),
	secondary_contact_method varchar(100),
	registered_by varchar(100),
	foreign key (registered_by) references staff_member(stf_id))

	create trigger updating_customers ON customers
	after update
	as 
	begin
		INSERT INTO log VALUES(20, 'customers', 'updating values', '2020', '12', '12', '12', '12', 'staff-member')
	end

create table customer_contact(
	id varchar(100),
	foreign key (id) references customers(cus_id),
	phone_number varchar(100),
	email varchar(100),
	primary key(id,phone_number));

create table locker_details(
	id varchar(100) primary key,
	locker_name varchar(100),
	locker_owner varchar(100),
	description varchar(100),
	line1 varchar(100),
	line2 varchar(100),
	line3 varchar(100),
	city varchar(100),
	day varchar(100),
	month varchar(100),
	year varchar(100));

	create trigger udpating_lockerDetails ON locker_details
	after update
	as 
	begin
		INSERT INTO log VALUES(20, 'staff-member', 'updating values', '2020', '12', '12', '12', '12', 'staff-member')
	end

create table pawn_item(
	id varchar(100) primary key,
	owner_id varchar(100),
	foreign key (owner_id) references customers(cus_id),
	item_name varchar(100),
	description varchar(100),
	estimated_carrot_value varchar(100),
	description_approved_amount varchar(100),
	monthly_interest varchar(100),
	payment_method varchar(100),
	taken_amount varchar(100),
	calculate_interest_for varchar(100),
	approved_staff varchar(100),
	foreign key (approved_staff) references staff_member(stf_id),
	owner_verification varchar(100),
	foreign key (owner_verification) references staff_member(stf_id),
	estimated_value varchar(100),
	approved_amount varchar(100),
	stored_locker_id varchar(100),
	foreign key (stored_locker_id) references locker_details(id));

create table attendance(
	id varchar(100) primary key,
	in_day varchar(100),
	in_month varchar(100),
	in_year varchar(100),
	in_hour varchar(100),
	in_minute varchar(100),
	out_day varchar(100),
	out_month varchar(100),
	out_year varchar(100),
	out_hour varchar(100),
	out_minute varchar(100),
	member_id varchar(100),
	foreign key (member_id) references staff_member(stf_id));

create table pay_sheets(
	id varchar(100) primary key,
	employee_id varchar(100),
	foreign key (employee_id) references staff_member(stf_id),
	credited_by varchar(100),
	foreign key (credited_by) references staff_member(stf_id),
	bank_name varchar(100),
	amount varchar(100),
	day varchar(100),
	month varchar(100),
	year varchar(100),
	hour varchar(100),
	minute varchar(100),
	beneficial_month varchar(100),
	EPF_amount varchar(100),
	tax varchar(100),
	other varchar(100),
	description varchar(100),
	creadited_account_number varchar(100));


create table EPFETF(
	id varchar(100) primary key,
	worker_id varchar(100),
	foreign key (worker_id) references staff_member(stf_id),
	certifing_officer varchar(100),
	foreign key (certifing_officer) references staff_member(stf_id),
	registered_day varchar(100),
	registered_month varchar(100),
	registered_year varchar(100),
	registered_hour varchar(100),
	registered_minute varchar(100),
	member_conformation_day varchar(100),
	member_conformation_month varchar(100),
	member_conformation_year varchar(100),
	certified_day varchar(100),
	certified_month varchar(100),
	certified_year varchar(100),
	certified_hour varchar(100),
	certified_minute varchar(100),
	EPFETF_amount varchar(100),
	is_signed varchar(100));

create table EPFETF_previous_employment(
	id varchar(100),
	foreign key (id) references EPFETF(id),
	zone varchar(100),
	member_number varchar(100),
	primary key(id,member_number));

create table leaves(
	id varchar(100) primary key,
	staff_id varchar(100),
	foreign key (staff_id) references staff_member(stf_id),
	day varchar(100),
	month varchar(100),
	year varchar(100),
	hour varchar(100),
	minute varchar(100),
	wanted_day varchar(100),
	wanted_month varchar(100),
	wanted_year varchar(100),
	wanted_hour varchar(100),
	wanted_minute varchar(100),
	reason varchar(100),
	approved_by varchar(100),
	foreign key (approved_by) references staff_member(stf_id),
	approved_status varchar(100),
	job_replacement varchar(100),
	foreign key (job_replacement) references staff_member(stf_id));

create table payment_log(
	id varchar(100) primary key,
	table_refered varchar(100),
	description varchar(100),
	day varchar(100),
	month varchar(100),
	year varchar(100),
	hour varchar(100),
	minute varchar(100),
	transfered_amount varchar(100),
	account_number varchar(100),
	bank varchar(100),
	action_performed_by varchar(100),
	foreign key (action_performed_by) references staff_member(stf_id),
	capital varchar(100),
	payment_method varchar(100),
	transaction_confirmation varchar(100));

create table log(
	id varchar(100) primary key,
	table_refered varchar(100),
	description varchar(100),
	day varchar(100),
	month varchar(100),
	year varchar(100),
	hour varchar(100),
	minute varchar(100),
	action_performed_by varchar(100),
	foreign key (action_performed_by) references staff_member(stf_id));

create table staff_contact_number(
	id varchar(100),
	foreign key (id) references pawn_item(id),
	phone_number varchar(100),
	email varchar(100),
	bank_account_number varchar(100),
	primary key(id,phone_number));

create table remind_letters(
	id varchar(100) primary key,
	day varchar(100),
	month varchar(100),
	year varchar(100),
	hour varchar(100),
	minute varchar(100),
	line1 varchar(100),
	line2 varchar(100),
	line3 varchar(100),
	city varchar(100),
	is_second varchar(100),
	related_month varchar(100),
	customer_id varchar(100),
	foreign key (customer_id) references customers(cus_id),
	item_id varchar(100),
	foreign key (item_id) references pawn_item(id),
	written_by varchar(100),
	foreign key (written_by) references staff_member(stf_id));

create table bills(
	id varchar(100) primary key,
	customer_id varchar(100),
	foreign key (customer_id) references customers(cus_id),
	details_filled_by varchar(100),
	foreign key (details_filled_by) references staff_member(stf_id),
	is_customer_aware varchar(100),
	type varchar(100),
	is_income varchar(100),
	interest varchar(100),
	capital varchar(100),
	total varchar(100),
	day varchar(100),
	month varchar(100),
	year varchar(100),
	hour varchar(100),
	minute varchar(100),
	item_name varchar(100));

create table blacklisted_customers(
	id varchar(100),
	foreign key (id) references customers(cus_id),
	first_name varchar(100),
	last_name varchar(100),
	other_names varchar(100),
	line1 varchar(100),
	line2 varchar(100),
	line3 varchar(100),
	city varchar(100),
	reason varchar(100),
	blocked_by varchar(100),
	foreign key (blocked_by) references staff_member(stf_id),
	primary key(id,first_name));

create table other_vendors(
	id varchar(100) primary key,
	owner_id varchar(100),
	foreign key (owner_id) references staff_member(stf_id),
	item_id varchar(100),
	foreign key (item_id) references pawn_item(id),
	owner_verification varchar(100),
	foreign key (owner_verification) references staff_member(stf_id),
	transaction_conformed_by varchar(100),
	foreign key (transaction_conformed_by) references staff_member(stf_id),
	transaction_verification varchar(100),
	final_deal_amount varchar(100),
	status_when_buying varchar(100),
	day varchar(100),
	month varchar(100),
	year varchar(100),
	hour varchar(100),
	minute varchar(100),
	status_checked_by varchar(100),
	foreign key (transaction_conformed_by) references staff_member(stf_id),
	organization_name varchar(100));

create table other_vendor_contact(
	id varchar(100),
	foreign key (id) references other_vendors(id),
	phone_number varchar(100),
	primary key(id,phone_number));
