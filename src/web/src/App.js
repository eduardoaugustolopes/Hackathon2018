import React from 'react';
import Radium, { StyleRoot } from 'radium';

import 'spectre.css/dist/spectre.min.css';
import 'spectre.css/dist/spectre-exp.min.css';
import 'spectre.css/dist/spectre-icons.min.css';
import 'spectre.css/docs/dist/docs.css';

import Navbar from './components/Navbar';
import Sidebar from './components/Sidebar';
import Content from './components/Content';
import Login from './Login'

const App = () => (
  <StyleRoot>
    <Login />
  </StyleRoot>
);

export default Radium(App);


/*<StyleRoot>
    <div className="App docs-container off-canvas off-canvas-sidebar-show">
      <Navbar />
      <Sidebar />
      <Content />
      <a className="off-canvas-overlay" href="#close"></a>
    </div>
  </StyleRoot>*/