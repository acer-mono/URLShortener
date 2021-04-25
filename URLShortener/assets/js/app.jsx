import React from 'react';
import ReactDOM from 'react-dom';
import '../img/clipboard.svg';
import fetchShortUrl from './api';
import Form from './Form/Form';

const root = document.getElementById('root');
const endpoint = root.dataset.endpoint; 

const layout = (
    <div className="layout">
        <Form fetchShortUrl={fetchShortUrl(endpoint)} />
    </div>
);

ReactDOM.render(layout, root);
