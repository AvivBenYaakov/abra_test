
import './App.css';
import React, { useEffect, useState } from 'react';
import Select from 'react-select'
import { getPets, addPet } from './services/PetService';


function App() {
  const [pets, setPets] = useState([]);
  const [name, setName] = useState("");
  const [age, setAge] = useState(0);
  const [type, setType] = useState("");
  const [color, setColor] = useState("");
  
  const [selectedPet, setSelectedPet] = useState(null);

  const PetTypes = [
    { value: 'dog', label: 'Dog' },
    { value: 'cat', label: 'Cat' },
    { value: 'horse', label: 'Horse' },
    { value: 'other', label: 'Other' }
  ]

  useEffect(() => {
    const fetchPets = async () => {
        try {
            const result = await getPets();
            setPets(result);
        } catch (error) {
            console.error('Error fetching Pets', error);
        }
    };
    fetchPets();
}, []);

const handleAddPet = async () => {
    try {
        const addedPet = await addPet(
          {name: {name}, age: {age}, type: {type}, color: {color}});
        setPets([...pets, addedPet]);
    } catch (error) {
        console.error('Error adding Pet', error);
    }
};

const handleNameChange = (event) => {
  setName(event.target.value);
}

const handlAgeChange = (event) => {
  setAge(event.target.value);
}

const handlColorChnage = (event) => {
  setColor(event.target.value);
}

  return (
    <div className="App">
      <header className="App-header">
        <form>
          <label>
            Name:
            <input type="text" name="name" maxLength={25} onChange={handleNameChange}/>
          </label>
          <br></br>
          <Select placeholder="Select Type" options={PetTypes} />
          <br></br>
          <label>
            Color:
            <input type="text" name="name" onChange={handlColorChnage} />
          </label>
          <br></br>
          <label>
            Age:
            <input type="number" min={0} max={20} name="name" onChange={handlAgeChange} />
          </label>
          <br></br>
          <button onClick={handleAddPet}>Add Pet</button>
        </form>
      </header>
    </div>
  );
}

export default App;
