function delay(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

async function hatchPet(element) {
  var petId = element.getAttribute('data-petid');
  var formId = `hatchForm-${petId}`
  await delay(10000); 
  document.getElementById(formId).submit();
}

async function sleepPet(petId) {
  await delay(5000); 
  document.getElementById(`sleeping-${petId}`).submit();
}

async function playPet(petId) {
  await delay(5000); 
  document.getElementById(`playing-${petId}`).submit();
}

async function feedPet(petId) {
  await delay(5000); 
  document.getElementById(`eating-${petId}`).submit();
}