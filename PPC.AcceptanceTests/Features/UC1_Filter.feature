@automated
Feature: UC1_Filter
	In order to search project
	As a user of the website
	I want to search project

Background: 
	Given the following project:
	| PropertyName                                 | Avarta                                           | Images                                                                             | PropertyType_ID | Content                                                                                                     | Street_ID      | Ward_ID	| District_ID  | Price  | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace | UserID | Create_at  | Create_post | Status_ID | Note | Update_at  | Sale_ID |
	| PIS Top Apartment                            | PIS_6656-Edit-stamp.jpg                          | a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg, | 1				| The surrounding neighborhood is very much localized with a great number of local shops.                      | 748			|    2		| 2			| 10000  | VND       | 120m2 | 3       | 2        | 1            | 1      | 2017-11-09 | 2017-11-09  | 3		| Done | 2017-11-23 | 2       |
	| ViLa Q7                                      |  PIS_6656-Edit-stamp.jpg                         |PIS_6656-Edit-stamp.jpg														       | 2			    | Brand new apartments with unbelievable river and city view, completely renovated and tastefully furnished.   | 750			|  3		| 2			| 70000  | VND       | 120m2 | 3       | 4        | 1            | 1      | 2017-11-09 | 2017-11-09  | 3		| Done | 2017-11-23 | 2       |
	| PIS Serviced Apartment – Style               | sunshine-benthanh-cityhome-10-stamp174228283.jpg | PIS_6656-Edit-stamp.jpg														   	   | 1			    | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs..          | 749			|  4		| 2			| 30000  | VND       | 130m2 | 2       | 3        | 1            | 4      | 2017-11-09 | 2017-11-09  | 3		| Done | 2017-11-23 | 3       |
	| Vinhomes Central Park L2 – Duong’s Apartment | PIS_7389-Edit-stamp.jpg                          | images1702244617042862.jpg,                                                        | 3			    | Vinhomes Central Park is a new development that is in the heart of everything that Ho Chi Minh has to offer. | 752			| 5			| 2			| 110000 | VND       | 150m2 | 4       | 2        | 1            | 1      | 2017-11-09 | 2017-11-09  | 3		| Done | 2017-11-23 | 3       |
	| Saigon Pearl Ruby Block                      | PIS_7319-Edit-stamp.jpg                          | images17423697317334243.jpg,PIS_4622-Edit17463610217334244.jpg,                    | 1				| Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker Area, 23/9 park…            | 755			|  33		| 3			| 30000  | VND       | 130m2 | 3       | 5        | 1            | 4      | 2017-11-09 | 2017-11-09  | 3		| Done | 2017-11-23 | 2       |

Scenario: search project
	When I search for projects by the phrase 'PIS','1','3'
	Then project should display project with projectname follow 'PIS Top Apartment'
	
	

