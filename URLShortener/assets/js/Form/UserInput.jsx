import React, { useState } from 'react';

export default props => {
    const [originalUrl, setOriginalUrl] = useState('');
    const [isButtonEnabled, toggleButtonState] = useState(false);
    
    return (
        <div className="user-input">
            <input
                type="text"
                className="user-input__url"
                placeholder="Enter a URL and press Enter"
                onInput={onInput(setOriginalUrl, toggleButtonState)} />
            <button
                className="user-input__submit"
                disabled={!isButtonEnabled}
                onClick={onButtonClick(originalUrl, props.onSubmit)}>Shorten!</button>
        </div>
    );
};

function onInput(setOriginalUrl, toggleButtonState) {
    return event => {
        setOriginalUrl(event.target.value);
        toggleButtonState(event.target.value !== '');
    };
}

function onButtonClick(originalUrl, onSubmit) {
    return event => onSubmit(originalUrl, event);
}