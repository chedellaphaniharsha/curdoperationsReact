import React, { Component } from 'react';

import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Route } from "react-router-dom";
import RegisterUser from './components/RegisterUser';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      // <Layout>
      //   <Route exact path='/' component={Home} />
      //   <Route path='/counter' component={Counter} />
      //   <Route path='/fetch-data' component={FetchData} />
      // </Layout>

      <div className="container">
            <RegisterUser />
         {/* <Routes>*/}
            <Route path="/RegisterUser" element={<RegisterUser />} />
          {/*</Routes>*/}
      
      </div>
    );
  }
}
