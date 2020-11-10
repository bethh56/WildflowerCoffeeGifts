import React, { useState } from 'react';
import { FaStar } from 'react-icons/fa';
// npm install --save react-icons
import './StarRating.scss';

const StarRating = () => {
  const [rating, setRating] = useState(4);
  // const [hover, setHover] = useState(null);

  return (
<div>
  {[...Array(5)].map((star, i) => {
    const ratingValue = i + 1;
    return (
    <label>
      <input
      type="radio"
      name="rating"
      value={ratingValue}
      onClick={() => setRating(ratingValue)}
      />
      <FaStar className="star"
      color={ratingValue <= rating ? '#ffc107' : '#e4e5e9'}
      size={25}
      // onMouseEnter={() => setHover(ratingValue)}
     // onMouseLeave={() => setHover(null)}
      />
    </label>
    );
  })}
<p>This rating is {rating} stars!</p>
</div>
  );
};

export default StarRating;