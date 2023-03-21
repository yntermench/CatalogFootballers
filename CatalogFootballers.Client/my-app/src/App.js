import React from 'react';
import {Routes, Route, BrowserRouter} from 'react-router-dom';
import CreateFootballerForm from './components/CreateFootballerForm.js';
import GetFootballers from './components/GetFootballers.js';
import EditFootballerForm from './components/EditFootballerForm.js';

const Header = () => <div className="col d-flex flex-column justify-content-center align-items-center"><h1>Каталог футболистов</h1></div> 

function App() {
  return (
    <>
    <Header/>
    <BrowserRouter>
      <Routes>
        <Route exact path="/" element={<CreateFootballerForm/>}/>
        <Route path="/footballer/edit/:id" element={<EditFootballerForm/>}/>
        <Route path="/table/footballers" element={<GetFootballers/>}/>
      </Routes>
    </BrowserRouter>
    </>
  );
}

export default App;
