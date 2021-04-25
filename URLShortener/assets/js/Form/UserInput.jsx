import React, { useState } from 'react';

export default ({onSubmit}) => {
    const [originalUrl, setOriginalUrl] = useState('');
    const [isButtonEnabled, toggleButtonState] = useState(false);
    
    const onButtonClick = event => onSubmit(originalUrl, event);
    const onInput = event => {
        setOriginalUrl(event.target.value);
        toggleButtonState(event.target.value !== '');
    };
    
    return (
        <div className="user-input">
            <input
                type="text"
                className="user-input__url"
                placeholder="Enter a URL and press Enter"
                onInput={onInput} />
            <button
                className="user-input__submit"
                disabled={!isButtonEnabled}
                onClick={onButtonClick}>Shorten!</button>
        </div>
    );
};
