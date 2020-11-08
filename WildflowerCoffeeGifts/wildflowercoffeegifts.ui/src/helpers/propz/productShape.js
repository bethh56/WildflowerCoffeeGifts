import PropTypes from 'prop-types';

const productShape = PropTypes.shape({
  id: PropTypes.number.isRequired,
  title: PropTypes.string.isRequired,
  imageUrl: PropTypes.string.isRequired,
  productThemeId: PropTypes.number.isRequired,
  price: PropTypes.decimal.isRequired,
  description: PropTypes.string.isRequired,
  dateCreated: PropTypes.datetime.isRequired,
  coffeeMugId: PropTypes.number.isRequired,
  flowerArrId: PropTypes.number.isRequired,
  quantityAvailable: PropTypes.number.isRequired,
  isActive: PropTypes.bool.isRequired,
});

export default { productShape };
