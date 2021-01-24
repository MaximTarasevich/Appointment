import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore } from "redux";
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import { rootReducer } from './redux/reducers';

const store = createStore(rootReducer);

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
  	<BrowserRouter basename={baseUrl}>
		<Provider store={store}>
			<App />
		</Provider>
  	</BrowserRouter>,
	rootElement
);

rootElement.firstChild.style.height = '100%';

