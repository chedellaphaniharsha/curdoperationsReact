import React, { Component } from 'react';

import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import ReadUserDetails from './components/ReadUserDetails'
import RegisterUser from './components/RegisterUser';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
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
          <Switch>
            {/* <Route  exact path="/" element={<RegisterUser />} />  */}
            <Route exact path='/' component={RegisterUser} />
            <Route exact path='/ReadUserDetails' component={ReadUserDetails} />
          </Switch>

        </div>
    );
  }
}
