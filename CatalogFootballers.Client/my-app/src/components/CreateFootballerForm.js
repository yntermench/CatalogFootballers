import React, { useState } from "react";
import { useNavigate  } from 'react-router-dom'; 

export default function CreateFootballerForm() {
  const [formData, setFormData] = useState("");
  const [formDataTitleCommand, setDataTitleCommand] = useState("");
  const [titlesCommands, setTitlesCommands] = useState([]);
  const [countries, setCountries] = useState([]);
  const [showFormTitleCommand, setFormTitleCommand] = useState(false);
  const [selectedKeyOption, setSelectedKeyOption] = useState(0);
  const [country, setCountry] = useState({});
  const navigate = useNavigate();

  const getTitleCommands = () => {
    fetch(process.env.REACT_APP_API + "/titleCommand/getAll", {
      method: "GET",
    })
      .then((response) => response.json())
      .then((titlesCommandsFromServer) => {
        setTitlesCommands(titlesCommandsFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  };

  const getCountries = () => {
    fetch(process.env.REACT_APP_API + "/country/getAll", {
      method: "GET",
    })
      .then((response) => response.json())
      .then((countriesFromServer) => {
        setCountries(countriesFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  };

  const handleChange = (e) => {
    setFormTitleCommand(e.target.value === "addNewTitleCommand");

    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleChangeTitleCommand = (e) => {
    setDataTitleCommand({
      ...formDataTitleCommand,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const footballerToCreate = {
      firstName: formData.firstName,
      lastName: formData.lastName,
      gender: formData.gender,
      dateOfBirth: formData.dateOfBirth,
      country: country,
      titleCommandId: selectedKeyOption,
    };

    fetch(process.env.REACT_APP_API + "/footballer/create", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(footballerToCreate),
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
        navigate("/table/footballers")
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  };

  const handleSubmitTitleCommand = (e) => {
    e.preventDefault();

    const titleCommandToCreate = {
      id: 0,
      title: formDataTitleCommand.title,
    };

    fetch(process.env.REACT_APP_API + "/titleCommand/create", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(titleCommandToCreate),
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  };

  const handleSelectChangeCommand = (e) => {
    setFormTitleCommand(e.target.value === "addNewTitleCommand");
    const selectedIndex = e.target.options.selectedIndex;
    const selectedKey = e.target.options[selectedIndex].getAttribute("data-id");
    setSelectedKeyOption(selectedKey);
  };

  const handleSelectChangeCountry = (e) => {
    const selectedIndex = e.target.options.selectedIndex;
    const selectedCountry = e.target.options[selectedIndex].value;
    setCountry(selectedCountry)
  }

  getTitleCommands();
  getCountries();
  return (
    <div>
      <form className="w-200 px-5">
        <h1 className="mt-3">Добавить футболиста</h1>

        <div className="mt-5">
          <label className="h3 form-label">Имя</label>
          <input
            value={formData.firstName}
            name="firstName"
            placeholder="Введите имя"
            type="text"
            className="form-control"
            onChange={handleChange}
          ></input>
        </div>

        <div className="mt-5">
          <label className="h3 form-label">Фамилия</label>
          <input
            value={formData.lastName}
            placeholder="Введите фамилию"
            name="lastName"
            type="text"
            className="form-control"
            onChange={handleChange}
          ></input>
        </div>

        <div className="mt-5">
          <label className="h3 form-label">Пол</label>
          <input
            value={formData.gender}
            placeholder="Введите пол"
            name="gender"
            type="text"
            className="form-control"
            onChange={handleChange}
          ></input>
        </div>

        <div className="mt-5">
          <label className="h3 form-label">Дата рождения</label>
          <input
            value={formData.dateOfBirth}
            name="dateOfBirth"
            placeholder="Выберите дату рождения"
            type="date"
            className="form-control"
            onChange={handleChange}
          ></input>
        </div>

        <div className="mt-5">
          <label className="h3 form-label">Имя команды</label>
          <select
            name="select1"
            onChange={handleSelectChangeCommand}
            value={formData.titleCommandId}
          >
            <option value="">Выберите название команды</option>
            {titlesCommands.map((titleCommand) => (
              <option key={titleCommand.id} data-id={titleCommand.id}>
                {titleCommand.title}
              </option>
            ))}
            <option value="addNewTitleCommand">Добавить новую команду</option>
          </select>
        </div>

        {showFormTitleCommand && (
          <div>
            <form>
              <div className="mt-5">
                <label className="h3 form-label">Название команды</label>
                <input
                  value={formDataTitleCommand.title}
                  placeholder="Введите название команды"
                  name="title"
                  type="text"
                  className="form-control"
                  onChange={handleChangeTitleCommand}
                ></input>
                <button
                  type="submit"
                  className="btn btn-dark btn-lg w-50 mt-5"
                  onClick={handleSubmitTitleCommand}
                >
                  Добавить
                </button>
              </div>
            </form>
          </div>
        )}

        <div className="mt-5">
          <label className="h3 form-label">Страна</label>
          <select
            name="select2"
            onChange={handleSelectChangeCountry}
            value={formData.country}
          >
            <option value="">Выберите страну</option>
            {countries.map((country) => (
              <option key={country.value} >{country.key}</option>
            ))}
          </select>
        </div>
        <button
            type="submit"
            onClick={handleSubmit}
            className="btn btn-dark btn-lg w-100 mt-5"
          >
            Добавить
          </button>
      </form>
    </div>
  );
}
