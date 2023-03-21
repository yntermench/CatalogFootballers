import React, { useState } from "react";
import { Link } from "react-router-dom";

export default function GetFootballers(id) {
  const [footballers, setFootballers] = useState([]);
  
  const deleteFootballer = (id) => {
    fetch(process.env.REACT_APP_API + `/footballer/delete/${id}`, {
      method: "DELETE",
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

  const getFootballers = () => {
    fetch(process.env.REACT_APP_API + "/footballer/getAll", {
      method: "GET",
    })
      .then((response) => response.json())
      .then((footballersFromServer) => {
        console.log(footballersFromServer);
        setFootballers(footballersFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  };
  getFootballers()
  return (
    <div>
      <div className="table-responsive mt-3">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">Id</th>
              <th scope="col">Имя</th>
              <th scope="col">Фамилия</th>
              <th scope="col">Пол</th>
              <th scope="col">Дата рождения</th>
              <th scope="col">Страна</th>
              <th scope="col">Название команды</th>
              <th scope="col">CRUD Операции</th>
            </tr>
          </thead>
          <tbody>
            {footballers.map((footballer) => (
              <tr key={footballer.id}>
                <th scope="row">{footballer.id}</th>
                <td>{footballer.firstName}</td>
                <td>{footballer.lastName}</td>
                <td>{footballer.gender}</td>
                <td>{new Date(footballer.dateOfBirth).toDateString()}</td>
                <td>{footballer.country}</td>
                <td>{footballer.titleCommand.title}</td>
                <td>
                  <Link 
                  to={`/footballer/edit/${footballer.id}`}>
                  <button className="btn btn-dark btn-lg mx-3 my-3">
                    Изменить
                  </button>
                  </Link>
                  <button onClick={() => { if(window.confirm(`Вы уверены, что хотите удалить футболиста ${footballer.firstName} ${footballer.lastName}?`)) deleteFootballer(footballer.id)}}  className="btn btn-secondary btn-lg">Удалить</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
