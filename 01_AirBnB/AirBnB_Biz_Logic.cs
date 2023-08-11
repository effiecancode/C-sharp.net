namespace AirBnB;

public class BizLogic
{
	private List<City> CityList {get; set;}
	private List<State> StateList {get; set;}
	private List<Amenities> AmenitiesList {get; set;}
	// this is a constructor-method with same name as
	// the class but no return parameter, called when a clss in first initialized
	// parameterless constructor

public BizLogic()
{
	// initializing empty list
	CityList = new List<City>();
	StateList = new List<State>();
	AmenitiesList = new List<Amenities>();
}

// constructor with parameters
public BizLogic(List<City> ListofCities, List<State> ListofStates, List<Amenities> ListofAmenities)
{
	CityList = ListofCities;
	StateList = ListofStates;
	AmenitiesList = ListofAmenities;
}

// method to allow create new instance of a City
public void Add_City(string name, int id, State state)
{
	City new_City = new City();
	new_City.Name = name;
	new_City.Id = id;
	new_City.CityState = state;
	CityList.Add(new_City);
}

//method to return a list of Cities
public List<City> Get_Cities()
{
	return CityList;
}

//method add State
public State Add_State(string name, int id)
{
	State new_State = new State();
	new_State.Name = name;
	new_State.Id = id;
	StateList.Add(new_State);
	return new_State;
}

//method to return a list of States
public List<State> Get_States()
{
	return StateList;
}

//method add Amenities
public void Add_Amenities(string name, int id)
{
	Amenities new_Amenities = new Amenities();
	new_Amenities.Name = name;
	new_Amenities.Id = id;
	AmenitiesList.Add(new_Amenities);
}

//method to return a list of Amenities
public List<Amenities> Get_Amenities()
{
	return AmenitiesList;
}

}
